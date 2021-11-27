using Left4DeadAddonsDownloader.Core.Models.Entities;
using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using Left4DeadAddonsDownloader.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace Left4DeadAddonsDownloader.Core.Services
{
    public class ExecutorService : IExecutorService
    {
        #region Fields

        private AppSettings appSettings;
        private string left4DeadValidAddons;
        private string localAppFolder;
        private string pathToDownload;
        private string userAgent;
        private readonly IFileDownloadedRepository _fileDownloadRepository;
        private readonly IAppSettingsRepository _appSettingsRepository;
        private List<string> progressLog;
        private BackgroundWorker BackgroundWorker { get; set; }
        private int Percentage { get; set; }

        #endregion

        #region Properties

        private List<string> ProgressLog
        {
            get
            {
                if (progressLog == null)
                    progressLog = new List<string>();
                return progressLog;
            }
            set
            {
                progressLog = value;
            }
        }

        #endregion

        #region Construtros

        public ExecutorService(IFileDownloadedRepository fileDownloadRepository, IAppSettingsRepository appSettingsRepository)
        {
            this._fileDownloadRepository = fileDownloadRepository;
            this._appSettingsRepository = appSettingsRepository;
        }

        #endregion

        #region Methods

        public void Start(BackgroundWorker background)
        {
            BackgroundWorker = background;

            // ConsoleMessage.Write("Processo iniciado", TypeMessage.INFORMATION);
            this.AddProgressLog("Processo iniciado");

            this.ReadAppSettings();
            this.InicializeProperties();
            this.CheckLeft4DeadAddonsFolder();
            this.DownloadVpkFiles(GetUrlListsToDownload());
            this.ExtractFilesToAddonsFolder();
            this.HoldenOnlyVPKFiles();
#if DEBUG
            this.OpenAddonsFolder();
#endif
            // this.Exit();
        }

        public void OpenAddonsFolder()
        {
            Process.Start("explorer.exe", appSettings.Config.Left4DeadAddonsFolder);
        }

        public void InicializeProperties()
        {
            localAppFolder = AppDomain.CurrentDomain.BaseDirectory;
            pathToDownload = $"{localAppFolder}{appSettings.Config.TemporaryDownloadFolder}";
            string osVersion = DetectOperationSystem();
            userAgent = "User-Agent: Mozilla/5.0 (compatible; Left4DeadAddonsDownloader/1.0.0-alpha; +https://github.com/mchomem/Left4DeadAddonsDownloader)";

#if DEBUG
            // ConsoleMessage.Write(userAgent, TypeMessage.INFORMATION);
            this.AddProgressLog(userAgent);
#endif
        }

        public void Exit()
        {
            int value = 1;
            // ConsoleMessage.Write($"Encerrando aplicação em { value } minuto", TypeMessage.INFORMATION);
            this.AddProgressLog($"Encerrando aplicação em { value } minuto");            

            Log.Add(string.Empty.PadLeft(150, '='));
            Thread.Sleep(new TimeSpan(0, value, 0));
            Environment.Exit(0);
        }

        public string DetectOperationSystem()
        {
            OperatingSystem os = Environment.OSVersion;
            // ConsoleMessage.Write($"Sistema operacional detectado { os.VersionString }", TypeMessage.INFORMATION);
            this.AddProgressLog($"Sistema operacional detectado { os.VersionString }");
            return os.Version.ToString(2);
        }

        public void CheckLeft4DeadAddonsFolder()
        {
            // ConsoleMessage.Write("Verificando diretório addons do Left 4 Dead. Aguarde", TypeMessage.INFORMATION);
            this.AddProgressLog("Verificando diretório addons do Left 4 Dead. Aguarde");

            this.left4DeadValidAddons = this.appSettings.Config.Left4DeadAddonsFolder;

            if (!Directory.Exists(this.left4DeadValidAddons))
            {
                // ConsoleMessage.Write("O local dos Addons não foi localizado na sua máquina. Verifique a sua instalação de Left 4 Dead", TypeMessage.WARNING);
                this.AddProgressLog("O local dos Addons não foi localizado na sua máquina. Verifique a sua instalação de Left 4 Dead");
                this.Exit();
            }
        }

        public List<FileToDownload> GetUrlListsToDownload()
        {
            List<FileToDownload> filesToDonwload = new List<FileToDownload>();

            try
            {
                string content = string.Empty;

                if (this.appSettings.Config.Method.Equals("web"))
                {
                    using (WebClient client = new WebClient())
                    {
                        Stream repoUrlDownloads = client.OpenRead($"{ this.appSettings.Config.DownloadListUrl }/{ this.appSettings.Config.UrlListFile }");
                        StreamReader reader = new StreamReader(repoUrlDownloads);
                        content = reader.ReadToEnd();
                    }
                }
                else
                {
                    using (StreamReader sw = new StreamReader($"{ this.localAppFolder }{ this.appSettings.Config.UrlListFile }"))
                        content = sw.ReadToEnd();
                }

                filesToDonwload = JsonConvert.DeserializeObject<JsonModel>(content).FilesToDownload;
                string plural = filesToDonwload.Count > 1 ? "s" : string.Empty;
                // ConsoleMessage.Write($"Listagem de url's pronta com { filesToDonwload.Count } mapa{ plural }", TypeMessage.INFORMATION);
                this.AddProgressLog($"Listagem de url's pronta com { filesToDonwload.Count } mapa{ plural }");

                return filesToDonwload;
            }
            catch (Exception e)
            {
                // ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                this.AddProgressLog($"Falha: { e.Message }");
                throw;
            }
        }

        public bool FileAlreadyDownloaded(string url, out FileDownloaded file)
        {
            file = new FileDownloaded();
            string fileName = string.Empty;
            int fileSize = 0;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add(userAgent);
                var data = client.DownloadData(url);

                if (!string.IsNullOrEmpty(client.ResponseHeaders["Content-Disposition"]))
                    file.Name = client.ResponseHeaders["Content-Disposition"].Substring(client.ResponseHeaders["Content-Disposition"].IndexOf("filename=") + 9).Replace("\"", "");

                if (!string.IsNullOrEmpty(client.ResponseHeaders["x-bz-file-name"]))
                    file.Name = client.ResponseHeaders["x-bz-file-name"].Split("/")[3];

                file.Size = Convert.ToInt32(client.ResponseHeaders["Content-Length"]);
                fileName = file.Name;
                fileSize = file.Size;

                if (this._fileDownloadRepository.Select().Any(x => x.Name.Equals(fileName)
                    && x.Size == fileSize && x.UrlOrigin == url))
                    return true;
            }

            return false;
        }

        public void DownloadVpkFiles(List<FileToDownload> filesToDownlaoad)
        {
            CreateTempFolder();

            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < filesToDownlaoad.Count; i++)
                {
                    FileDownloaded file = new FileDownloaded();
                    string url = filesToDownlaoad[i].Url;

                    try
                    {
                        if (this.FileAlreadyDownloaded(url, out file))
                        {
                            // ConsoleMessage.Write($"Ignorando arquivo { file.Name } já baixado anteriormente", TypeMessage.WARNING);
                            this.AddProgressLog($"Ignorando arquivo { file.Name } já baixado anteriormente");
                            continue;
                        }

                        string idMap = string.Empty;
                        client.Headers.Add(userAgent);

                        if (this.appSettings.Credential.Enabled)
                            client.Credentials =
                                new NetworkCredential(this.appSettings.Credential.User, this.appSettings.Credential.Password);

                        if (string.IsNullOrEmpty(file.Name))
                        {
                            if (url.Contains("gamemaps.com"))
                                file.Name = url.Split("/")[5]; // Obtém o ID do mapa na quinta posição do indice da url.                            

                            client.DownloadFile(url, @$"{ pathToDownload }\{ file.Name }.zip");
                        }
                        else
                            client.DownloadFile(url, @$"{ pathToDownload }\{ file.Name }");

                        this._fileDownloadRepository.Insert(new FileDownloaded()
                        {
                            Name = file.Name,
                            Size = file.Size,
                            UrlOrigin = url
                        });
                        // ConsoleMessage.Write($"Arquivo { file.Name } baixado de { url }", TypeMessage.SUCCESS);
                        this.AddProgressLog($"Arquivo { file.Name } baixado de { url }");
                    }
                    catch (Exception e)
                    {
                        string formattedStackStrace = string.Empty;

                        if (!string.IsNullOrEmpty(e.StackTrace))
                        {
                            Regex regex = new Regex(Regex.Escape("at"));
                            formattedStackStrace = regex.Replace(e.StackTrace, "\r\n   at", 1);
                        }

                        // ConsoleMessage.Write($"Falha: { e.Message } StackTrace: { formattedStackStrace }", TypeMessage.ERROR);
                        this.AddProgressLog($"Falha: { e.Message } StackTrace: { formattedStackStrace }");
                        this.Exit();
                    }
                }
            }
        }

        public void ExtractFilesToAddonsFolder()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(pathToDownload);
                FileInfo[] zipFiles = dir.GetFiles();

                foreach (FileInfo zipVpk in zipFiles)
                {
                    ZipFile.ExtractToDirectory(zipVpk.FullName, left4DeadValidAddons, true);
                    // ConsoleMessage.Write($"Arquivo extraído para addons: { zipVpk.Name }", TypeMessage.SUCCESS);
                    this.AddProgressLog($"Arquivo extraído para addons: { zipVpk.Name }");
                }

                this.DeleteTempFolder();
            }
            catch (Exception e)
            {
                // ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                this.AddProgressLog($"Falha: { e.Message }");
            }
        }

        public void CreateTempFolder()
        {
            if (!Directory.Exists(pathToDownload))
            {
                Directory.CreateDirectory(pathToDownload);
                // ConsoleMessage.Write("Diretório temporário criado", TypeMessage.SUCCESS);
                this.AddProgressLog("Diretório temporário criado");
            }
        }

        public void DeleteTempFolder()
        {
            if (Directory.Exists(pathToDownload))
            {
                Directory.Delete(pathToDownload, true);
                // ConsoleMessage.Write("Diretório temporário excluído", TypeMessage.SUCCESS);
                this.AddProgressLog("Diretório temporário excluído");
            }
        }

        public void HoldenOnlyVPKFiles()
        {
            // ConsoleMessage.Write("Limpando diretório addons", TypeMessage.INFORMATION);
            this.AddProgressLog("Limpando diretório addons");
            DirectoryInfo di = new DirectoryInfo(this.left4DeadValidAddons);
            // Considera somente os arquivos que não sejam da extensão VPK (Valve Pak).
            FileInfo[] files = di.GetFiles().Where(p => !p.Extension.Equals(".vpk")).ToArray();

            foreach (FileInfo file in files)
            {
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                    // ConsoleMessage.Write($"Arquivo { file.Name } excluído", TypeMessage.SUCCESS);
                    this.AddProgressLog($"Arquivo { file.Name } excluído");
                }
                catch (Exception e)
                {
                    // ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                    this.AddProgressLog($"Falha: { e.Message }");
                }
            }
        }

        public void ReadAppSettings()
        {
            this.appSettings = this._appSettingsRepository.Details(null);
            this.AddProgressLog("Configuração carregada");
        }

        public void AddProgressLog(string text)
        {
            this.ProgressLog.Add($"[{ DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }]: { text }");
            this.BackgroundWorker.ReportProgress(++this.Percentage);
        }

        public List<string> GetProgressLog()
        {
            return this.ProgressLog;
        }

        #endregion
    }
}
