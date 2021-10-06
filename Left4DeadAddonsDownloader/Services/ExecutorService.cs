using Left4DeadAddonsDownloader.Models.Entities;
using Left4DeadAddonsDownloader.Models.Interfaces;
using Left4DeadAddonsDownloader.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;

namespace Left4DeadAddonsDownloader.Services
{
    public class ExecutorService : IExecutorService
    {
        #region Fields

        private AppConfiguration appSettings;
        private Credentials credentials;
        private string left4DeadValidAddons;
        private string localAppFolder;
        private string pathToDownload;
        private string userAgent;
        private readonly IFileDownloadedRepository _fileDownloadRepository;

        #endregion

        public ExecutorService(IFileDownloadedRepository fileDownloadRepository)
        {
            _fileDownloadRepository = fileDownloadRepository;
        }

        public void Start()
        {
            Console.Title = "Left 4 Dead Addons Downloader";
            ConsoleMessage.Write("Processo iniciado", TypeMessage.INFORMATION);

            ReadAppSettings();
            InicializeProperties();
            CheckLeft4DeadAddonsFolder();
            DownloadVpkFiles(GetUrlListsToDownload());
            ExtractFilesToAddonsFolder();
            HoldenOnlyVPKFiles();
#if DEBUG
            OpenAddonsFolder();
#endif
            Exit();
        }

        #region Methods

        public void OpenAddonsFolder()
        {
            Process.Start("explorer.exe", appSettings.Left4DeadAddonsFolder);
        }

        public void InicializeProperties()
        {
            localAppFolder = AppDomain.CurrentDomain.BaseDirectory;
            pathToDownload = $"{localAppFolder}{appSettings.TemporaryDownloadFolder}";
            string osVersion = DetectOperationSystem();
            userAgent = $"User-Agent: Mozilla/5.0 (Windows NT { osVersion }; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";
        }

        public void Exit()
        {
            int value = 1;
            ConsoleMessage.Write($"Encerrando aplicação em { value } minuto", TypeMessage.INFORMATION);
            Log.Add(string.Empty.PadLeft(150, '='));
            Thread.Sleep(new TimeSpan(0, value, 0));
            Environment.Exit(0);
        }

        public string DetectOperationSystem()
        {
            OperatingSystem os = Environment.OSVersion;
            ConsoleMessage.Write($"Sistema operacional detectado { os.VersionString }", TypeMessage.INFORMATION);
            return os.Version.ToString(2);
        }

        public void CheckLeft4DeadAddonsFolder()
        {
            ConsoleMessage.Write("Verificando diretório addons do Left 4 Dead. Aguarde", TypeMessage.INFORMATION);

            left4DeadValidAddons = appSettings.Left4DeadAddonsFolder;

            if (!Directory.Exists(left4DeadValidAddons))
            {
                ConsoleMessage.Write("O local dos Addons não foi localizado na sua máquina. Verifique a sua instalação de Left 4 Dead", TypeMessage.WARNING);
                Exit();
            }
        }

        public List<FileToDownload> GetUrlListsToDownload()
        {
            List<FileToDownload> filesToDonwload = new List<FileToDownload>();

            try
            {
                string content = string.Empty;

                if (appSettings.Method.Equals("web"))
                {
                    using (WebClient client = new WebClient())
                    {
                        Stream repoUrlDownloads = client.OpenRead($"{appSettings.DownloadListUrl}/{appSettings.FileList}");
                        StreamReader reader = new StreamReader(repoUrlDownloads);
                        content = reader.ReadToEnd();
                    }
                }
                else
                {
                    using (StreamReader sw = new StreamReader($"{localAppFolder}{appSettings.FileList}"))
                        content = sw.ReadToEnd();
                }

                filesToDonwload = JsonConvert.DeserializeObject<JsonModel>(content).FilesToDownload;
                string plural = filesToDonwload.Count > 1 ? "s" : string.Empty;
                ConsoleMessage.Write($"Listagem de url's pronta com { filesToDonwload.Count } mapa{ plural }", TypeMessage.INFORMATION);
                return filesToDonwload;
            }
            catch (Exception e)
            {
                ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                throw;
            }
        }

        public bool FileAlreadyDownloaded(string url, out FileDownloaded file)
        {
            file = new FileDownloaded();
            string fileName = string.Empty;
            int fileSize = 0;

            WebRequest req = WebRequest.Create(url);
            req.Headers.Add(userAgent);
            req.Method = "HEAD";

            using (WebResponse resp = req.GetResponse())
            {
                resp.Headers.Add(userAgent);

                if (!string.IsNullOrEmpty(resp.Headers["Content-Disposition"]))
                    file.Name = resp.Headers["Content-Disposition"].Substring(resp.Headers["Content-Disposition"].IndexOf("filename=") + 9).Replace("\"", "");

                if (!string.IsNullOrEmpty(resp.Headers["x-bz-file-name"]))
                    file.Name = resp.Headers["x-bz-file-name"].Split("/")[3];

                file.Size = Convert.ToInt32(resp.Headers["Content-Length"]);
                fileName = file.Name;
                fileSize = file.Size;

                if (_fileDownloadRepository.Select().Any(x => x.Name.Equals(fileName) && x.Size == fileSize && x.UrlOrigin == url))
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

                    if (FileAlreadyDownloaded(url, out file))
                    {
                        ConsoleMessage.Write($"Ignorando arquivo { file.Name } já baixado anteriormente", TypeMessage.WARNING);
                        continue;
                    }

                    try
                    {
                        string idMap = string.Empty;

                        client.Headers.Add(userAgent);

                        if (credentials.Enabled)
                            client.Credentials = new NetworkCredential(credentials.User, credentials.Password);

                        if (string.IsNullOrEmpty(file.Name))
                        {
                            if (url.Contains("gamemaps.com"))
                                file.Name = url.Split("/")[5]; // Obtém o ID do mapa na quinta posição do indice da url.                            

                            client.DownloadFile(url, @$"{ pathToDownload }\{ file.Name }.zip");
                        }
                        else
                            client.DownloadFile(url, @$"{ pathToDownload }\{ file.Name }");

                        _fileDownloadRepository.Insert(new FileDownloaded() { Name = file.Name, Size = file.Size, UrlOrigin = url });
                        ConsoleMessage.Write($"Arquivo { file.Name } baixado de { url }", TypeMessage.SUCCESS);
                    }
                    catch (Exception e)
                    {
                        ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
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
                    ConsoleMessage.Write($"Arquivo extraído para addons: { zipVpk.Name }", TypeMessage.SUCCESS);
                }

                DeleteTempFolder();
            }
            catch (Exception e)
            {
                ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
            }
        }

        public void CreateTempFolder()
        {
            if (!Directory.Exists(pathToDownload))
            {
                Directory.CreateDirectory(pathToDownload);
                ConsoleMessage.Write("Diretório temporário criado", TypeMessage.SUCCESS);
            }
        }

        public void DeleteTempFolder()
        {
            if (Directory.Exists(pathToDownload))
            {
                Directory.Delete(pathToDownload, true);
                ConsoleMessage.Write("Diretório temporário excluído", TypeMessage.SUCCESS);
            }
        }

        public void HoldenOnlyVPKFiles()
        {
            ConsoleMessage.Write("Limpando diretório addons", TypeMessage.INFORMATION);
            DirectoryInfo di = new DirectoryInfo(left4DeadValidAddons);
            // Considera somente os arquivos que não sejam da extensão VPK (Valve Pak).
            FileInfo[] files = di.GetFiles().Where(p => !p.Extension.Equals(".vpk")).ToArray();

            foreach (FileInfo file in files)
            {
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                    ConsoleMessage.Write($"Arquivo { file.Name } excluído", TypeMessage.SUCCESS);
                }
                catch (Exception e)
                {
                    ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                }
            }
        }

        public void ReadAppSettings()
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true);
                IConfigurationRoot config = builder.Build();

                appSettings = new AppConfiguration();
                appSettings.TemporaryDownloadFolder = config["AppConfiguration:TemporaryDownloadFolder"];
                appSettings.DownloadListUrl = config["AppConfiguration:DownloadListUrl"];
                appSettings.Left4DeadAddonsFolder = config["AppConfiguration:Left4DeadAddonsFolder"];
                appSettings.Method = config["AppConfiguration:Method"];
                appSettings.FileList = config["AppConfiguration:FileList"];
                appSettings.LogPath = config["AppConfiguration:LogPath"];

                credentials = new Credentials();
                credentials.Enabled = Convert.ToBoolean(config["Credentials:Enabled"]);
                credentials.User = config["Credentials:User"];
                credentials.Password = config["Credentials:Password"];

                ConsoleMessage.Write("Configuração carregada", TypeMessage.SUCCESS);
            }
            catch (Exception e)
            {
                ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
            }
        }

        #endregion
    }
}
