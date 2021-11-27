using System.IO;

namespace Left4DeadAddonsDownloader.Core.Models.Repositories
{
    public class JsonFileContext
    {
        public const string path = "./";
        public const string file = "appsettings.json";

        public JsonFileContext()
        {
            if(!File.Exists($"{path}{file}"))
            {
                StreamWriter sw = new StreamWriter($"{path}{file}");
                sw.Close();
            }
        }
    }
}
