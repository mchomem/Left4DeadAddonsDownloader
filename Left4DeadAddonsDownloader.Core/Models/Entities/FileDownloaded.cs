namespace Left4DeadAddonsDownloader.Core.Models.Entities
{
    public class FileDownloaded
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string UrlOrigin { get; set; }
        public bool DownloadAgain { get; set; }
    }
}
