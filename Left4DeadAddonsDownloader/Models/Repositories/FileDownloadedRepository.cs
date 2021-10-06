using Left4DeadAddonsDownloader.Models.Entities;
using Left4DeadAddonsDownloader.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Left4DeadAddonsDownloader.Models.Repositories
{
    public class FileDownloadedRepository : CsvFileContext, IFileDownloadedRepository
    {
        public void Delete(FileDownloaded file)
        {
            List<FileDownloaded> files = this.Select().Where(x => !x.Name.Equals(file.Name)).ToList();

            foreach (var item in files)
            {
                using (StreamWriter sw = new StreamWriter(path))
                    sw.WriteLine($"{file.Name};{file.Size};{file.UrlOrigin}");
            }
        }

        public void Insert(FileDownloaded file)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
                sw.WriteLine($"{file.Name};{file.Size};{file.UrlOrigin}");
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
                        Size = Convert.ToInt32(item.Split(';')[1]),
                        UrlOrigin = item.Split(';')[2]
                    });
                }
            }

            return files;
        }
    }
}
