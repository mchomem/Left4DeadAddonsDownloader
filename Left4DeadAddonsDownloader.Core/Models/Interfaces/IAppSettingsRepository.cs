using Left4DeadAddonsDownloader.Core.Models.Entities;
using System.Collections.Generic;

namespace Left4DeadAddonsDownloader.Core.Models.Interfaces
{
    public interface IAppSettingsRepository
    {
        public void Insert(AppSettings appSettings);
        public void Update(AppSettings appSettings);
        public AppSettings Details(AppSettings appSettings);
        public List<AppSettings> Select(AppSettings appSettings);
    }
}
