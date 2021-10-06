using Left4DeadAddonsDownloader.Models.Entities;
using System.Collections.Generic;

namespace Left4DeadAddonsDownloader.Models.Interfaces
{
    public interface IFileDownloadedRepository
    {
        public void Insert(FileDownloaded fileDownloaded);

        public void Delete(FileDownloaded fileDownloaded);

        public List<FileDownloaded> Select();
    }
}
