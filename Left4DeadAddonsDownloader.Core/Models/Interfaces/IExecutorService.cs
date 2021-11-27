using Left4DeadAddonsDownloader.Core.Models.Entities;
using System.Collections.Generic;

namespace Left4DeadAddonsDownloader.Core.Models.Interfaces
{
    public interface IExecutorService
    {
        void Start();
        void OpenAddonsFolder();
        void InicializeProperties();
        void Exit();
        string DetectOperationSystem();
        void CheckLeft4DeadAddonsFolder();
        List<FileToDownload> GetUrlListsToDownload();
        bool FileAlreadyDownloaded(string url, out FileDownloaded file);
        void DownloadVpkFiles(List<FileToDownload> filesToDownlaoad);
        void ExtractFilesToAddonsFolder();
        void CreateTempFolder();
        void DeleteTempFolder();
        void HoldenOnlyVPKFiles();
        void ReadAppSettings();
        void AddProgressLog(string text);
    }
}
