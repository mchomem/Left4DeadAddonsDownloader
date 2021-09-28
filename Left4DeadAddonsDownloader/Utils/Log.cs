using System.IO;

namespace Left4DeadAddonsDownloader.Utils
{
    public static class Log
    {
        public static void Add(string text, string path = "./Left4DeadAddonsDownloader.log")
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(text);
            }
        }
    }
}
