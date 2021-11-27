using System.IO;

namespace Left4DeadAddonsDownloader.Core.Models.Repositories
{
    public class CsvFileContext
    {
        public const string filePath = "./data.csv";

        public CsvFileContext()
        {
            if (!File.Exists(filePath))
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Close();
            }
        }

        public static void Destroy()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
