using Newtonsoft.Json;
using System.Collections.Generic;

namespace Left4DeadAddonsDownloader.Core.Models.Entities
{
    public class JsonModel
    {
        [JsonProperty(PropertyName = "FilesToDownload")]
        public List<FileToDownload> FilesToDownload { get; set; }
    }
}
