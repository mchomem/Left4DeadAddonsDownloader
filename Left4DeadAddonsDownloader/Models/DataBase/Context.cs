using Left4DeadAddonsDownloader.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Left4DeadAddonsDownloader.Models.DataBase
{
    public class Context
    {
        private string path = "./data.csv";

        public Context()
        {
            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Close();
            }
        }

        public void Insert(FileDownloaded file)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{file.Name};{file.Size}");
            }
        }

        public void Delete(FileDownloaded file)
        {
            List<FileDownloaded> files = this.Select().Where(x => !x.Name.Equals(file.Name)).ToList();

            foreach (var item in files)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"{item.Name};{item.Size}");
                }
            }
        }

        public List<FileDownloaded> Select()
        {
            List<FileDownloaded> files = new List<FileDownloaded>();
            List<string> rows = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string content = sr.ReadToEnd();
                rows = content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var item in rows)
                {
                    files.Add(new FileDownloaded()
                    {
                        Name = item.Split(';')[0],
                        Size = Convert.ToInt32(item.Split(';')[1])
                    });
                }
            }

            return files;
        }
    }
}
