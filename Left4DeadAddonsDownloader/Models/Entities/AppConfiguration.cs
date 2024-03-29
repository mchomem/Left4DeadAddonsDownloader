﻿namespace Left4DeadAddonsDownloader.Models.Entities
{
    public class AppConfiguration
    {
        public string TemporaryDownloadFolder { get; set; }
        public string DownloadListUrl { get; set; }
        public string Left4DeadAddonsFolder { get; set; }
        public string Method { get; set; }
        public string FileList { get; set; }
        public string LogPath { get; set; }
        public string IgnoreAaddonsExtensionsOnDeleting { get; set; }
    }
}
