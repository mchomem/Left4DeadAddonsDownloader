using Left4DeadAddonsDownloader.Core.Models.Entities;
using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Left4DeadAddonsDownloader.Core.Models.Repositories
{
    public class AppSettingsRepository : JsonFileContext, IAppSettingsRepository
    {
        public AppSettings Details(AppSettings appSettings)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .AddJsonFile(file, true, true);
            IConfigurationRoot configurationRoot = builder.Build();

            return new AppSettings()
            {
                Config = new Config()
                {
                    TemporaryDownloadFolder = configurationRoot["Config:TemporaryDownloadFolder"],
                    DownloadListUrl = configurationRoot["Config:DownloadListUrl"],
                    Left4DeadAddonsFolder = configurationRoot["Config:Left4DeadAddonsFolder"],
                    Method = configurationRoot["Config:Method"],
                    FileList = configurationRoot["Config:FileList"],
                    LogPath = configurationRoot["Config:LogPath"],
                    IsConfigured = Convert.ToBoolean(configurationRoot["Config:IsConfigured"])
                }                
            };
        }

        public void Insert(AppSettings appSettings)
        {
            appSettings = new AppSettings();

            var jsonWriteOptions = new JsonSerializerOptions() { WriteIndented = true };
            jsonWriteOptions.Converters.Add(new JsonStringEnumConverter());
            var newJson = JsonSerializer.Serialize(appSettings, jsonWriteOptions);

            var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);

            File.WriteAllText(appSettingsPath, newJson);
        }

        public List<AppSettings> Select(AppSettings appSettings)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AppSettings appSettings)
        {
            var jsonWriteOptions = new JsonSerializerOptions() { WriteIndented = true };
            jsonWriteOptions.Converters.Add(new JsonStringEnumConverter());
            var newJson = JsonSerializer.Serialize(appSettings, jsonWriteOptions);

            var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);

            File.WriteAllText(appSettingsPath, newJson);
        }
    }
}
