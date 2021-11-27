namespace Left4DeadAddonsDownloader.Core.Models.Entities
{
    public class Config
    {
        public string TemporaryDownloadFolder { get; set; }
        public string DownloadListUrl { get; set; }
        public string Left4DeadAddonsFolder { get; set; }
        public string Method { get; set; }
        public string UrlListFile { get; set; }
        public string LogPath { get; set; }
        public bool IsConfigured { get; set; }
    }
}
