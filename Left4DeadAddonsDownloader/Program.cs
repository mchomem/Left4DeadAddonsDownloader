using Left4DeadAddonsDownloader.Models;
using Left4DeadAddonsDownloader.Models.DataBase;
using Left4DeadAddonsDownloader.Models.Entities;
using Left4DeadAddonsDownloader.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;

namespace Left4DeadAddonsDownloader
{
    class Program
    {
        // Se a aplicação não funcionar deve ser instalado o runtime do dotnet core.
        // https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-5.0.10-windows-x64-installer

        #region Feilds

        private static AppConfiguration appSettings;
        private static Credentials credentials;
        private static string left4DeadValidAddons;
        private static string localAppFolder;
        private static string pathToDownload;

        #endregion

        #region Main method

        static void Main(string[] args)
        {
            Console.Title = "Left 4 Dead Addons Downloader";
            ConsoleMessage.Write("Processo iniciado", TypeMessage.INFORMATION);

            ReadAppSettings();
            InicializeProperties();

            if (!CheckLeft4DeadAddonsFolder())
            {
                ConsoleMessage.Write("O local dos Addons não foi localizado na sua máquina. Verifique a sua instalação de Left 4 Dead", TypeMessage.WARNING);
                Exit();
            }

            DownloadVpkFiles(GetUrlListsToDownload());
            ExtractFilesToAddonsFolder();
            HoldenOnlyVPK();
            Exit();
        }

        #endregion

        #region Methods

        private static void InicializeProperties()
        {
            localAppFolder = AppDomain.CurrentDomain.BaseDirectory;
            pathToDownload = $"{localAppFolder}{appSettings.TemporaryDownloadFolder}";
        }

        private static void Exit()
        {
            int value = 1;
            ConsoleMessage.Write($"Encerrando aplicação em { value } minuto", TypeMessage.INFORMATION);
            Log.Add(string.Empty.PadLeft(150, '='));
            Thread.Sleep(new TimeSpan(0, value, 0));
            Environment.Exit(0);
        }

        private static bool CheckLeft4DeadAddonsFolder()
        {
            ConsoleMessage.Write("Verificando diretório addons do Left 4 Dead. Aguarde", TypeMessage.INFORMATION);

            left4DeadValidAddons = appSettings.Left4DeadAddonsFolder;

            if (Directory.Exists(left4DeadValidAddons))
                return true;

            left4DeadValidAddons = string.Empty;
            return false;
        }

        private static List<string> GetUrlListsToDownload()
        {
            List<string> urlAddons = new List<string>();

            try
            {
                string content = string.Empty;

                if (appSettings.Method.Equals("web"))
                {
                    using (var client = new WebClient())
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

                urlAddons = content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
                urlAddons = urlAddons.Where(x => !x.Contains(";")).ToList(); // Exclui as linhas comentadas com ";".
                ConsoleMessage.Write("Listagem de url's pronta", TypeMessage.INFORMATION);
                return urlAddons;
            }
            catch (Exception e)
            {
                ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                throw;
            }
        }

        private static bool FileAlreadyDownloaded(string url, out FileDownloaded file)
        {
            file = new FileDownloaded();
            string fileName = string.Empty;
            int fileSize = 0;

            WebRequest req = WebRequest.Create(url);
            req.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36");
            req.Method = "HEAD";

            using (WebResponse resp = req.GetResponse())
            {
                resp.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36");

                if (!string.IsNullOrEmpty(resp.Headers["Content-Disposition"]))
                    file.Name = resp.Headers["Content-Disposition"].Substring(resp.Headers["Content-Disposition"].IndexOf("filename=") + 9).Replace("\"", "");

                if (!string.IsNullOrEmpty(resp.Headers["x-bz-file-name"]))
                    file.Name = resp.Headers["x-bz-file-name"].Split("/")[3];

                file.Size = Convert.ToInt32(resp.Headers["Content-Length"]);

                fileName = file.Name;
                fileSize = file.Size;

                // Verifica na lista se o arquivo já foi baixado e se por acaso o tamanho continua o mesmo em relação ao original baixado.
                if (new Context().Select().Any(x => x.Name.Equals(fileName) && x.Size == fileSize))
                    return true;
            }

            return false;
        }

        private static void DownloadVpkFiles(List<string> urls)
        {
            CreateTempFolder();

            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < urls.Count; i++)
                {
                    FileDownloaded file = new FileDownloaded();

                    if (FileAlreadyDownloaded(urls[i], out file))
                    {
                        ConsoleMessage.Write($"Ignorando arquivo { file.Name } já baixado anteriormente", TypeMessage.WARNING);
                        continue;
                    }

                    try
                    {
                        string url = urls[i];
                        string idMap = string.Empty;

                        client.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36");

                        if (credentials.Enabled)
                            client.Credentials = new NetworkCredential(credentials.User, credentials.Password);

                        if (url.Contains("gamemaps.com"))
                            idMap = url.Split("/")[5]; // Obtém o ID do mapa na quinta posição do indice da url.

                        if (string.IsNullOrEmpty(file.Name))
                        {
                            file.Name = idMap;
                            client.DownloadFile(url, @$"{ pathToDownload }\{ file.Name }.zip");
                        }
                        else
                            client.DownloadFile(url, @$"{ pathToDownload }\{ file.Name }");

                        new Context().Insert(new FileDownloaded() { Name = file.Name, Size = file.Size });

                        ConsoleMessage.Write($"Arquivo { file.Name } baixado de { url }", TypeMessage.SUCCESS);
                    }
                    catch (Exception e)
                    {
                        ConsoleMessage.Write($"Falha: { e.Message }", TypeMessage.ERROR);
                    }
                }
            }
        }

        private static void ExtractFilesToAddonsFolder()
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

        private static void CreateTempFolder()
        {
            if (!Directory.Exists(pathToDownload))
            {
                Directory.CreateDirectory(pathToDownload);
                ConsoleMessage.Write("Diretório temporário criado", TypeMessage.SUCCESS);
            }
        }

        private static void DeleteTempFolder()
        {
            if (Directory.Exists(pathToDownload))
            {
                Directory.Delete(pathToDownload, true);
                ConsoleMessage.Write("Diretório temporário excluído", TypeMessage.SUCCESS);
            }
        }

        private static void HoldenOnlyVPK()
        {
            DirectoryInfo di = new DirectoryInfo(left4DeadValidAddons);
            FileInfo[] files = di.GetFiles("*.txt").Where(p => p.Extension == ".txt").ToArray();

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

        private static void ReadAppSettings()
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
