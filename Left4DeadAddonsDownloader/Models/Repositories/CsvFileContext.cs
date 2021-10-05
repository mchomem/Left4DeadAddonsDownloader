using System.IO;

namespace Left4DeadAddonsDownloader.Models.Repositories
{
    public class CsvFileContext
    {
        public const string path = "./data.csv";

        public CsvFileContext()
        {
            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Close();
            }
        }       
    }
}
