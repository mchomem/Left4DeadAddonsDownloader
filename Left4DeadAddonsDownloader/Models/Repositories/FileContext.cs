using System.IO;

namespace Left4DeadAddonsDownloader.Models.Repositories
{
    public class FileContext
    {
        public const string path = "./data.csv";

        public FileContext()
        {
            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Close();
            }
        }       
    }
}
