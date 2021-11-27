using System.IO;
using System.Reflection;

namespace Left4DeadAddonsDownloader.Core.Utils
{
    public class Log
    {
        public static void Add(string text, string path = null)
        {
            if (string.IsNullOrEmpty(path))
                path = $"./{ AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name }.log";

            using (StreamWriter sw = new StreamWriter(path, true))
                sw.WriteLine(text);
        }
    }
}
