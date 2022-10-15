using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace Left4DeadAddonsDownloader.Models.Entities
{
    public class AppSettings
    {
        public static class AppConfiguration
        {
            public static string TemporaryDownloadFolder { get => GetValueFromKey("AppConfiguration:TemporaryDownloadFolder"); }
            public static string DownloadListUrl { get => GetValueFromKey("AppConfiguration:DownloadListUrl"); }
            public static string Left4DeadAddonsFolder { get => GetValueFromKey("AppConfiguration:Left4DeadAddonsFolder"); }
            public static string Method { get => GetValueFromKey("AppConfiguration:Method"); }
            public static string FileList { get => GetValueFromKey("AppConfiguration:FileList"); }
            public static string LogPath { get => GetValueFromKey("AppConfiguration:LogPath"); }
            public static string IgnoreAaddonsExtensionsOnDeleting { get => GetValueFromKey("AppConfiguration:IgnoreAaddonsExtensionsOnDeleting"); }
        }

        public static class Credential
        {
            public static bool Enabled { get => Convert.ToBoolean(GetValueFromKey("Credential:Enabled")); }
            public static string User { get => GetValueFromKey("Credential:User"); }
            public static string Password { get => GetValueFromKey("Credential:Password"); }
        }

        private static string GetValueFromKey(string key) => GetAppSettings().GetSection(key).Value;

        private static IConfigurationRoot GetAppSettings()
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
                IConfigurationRoot root = builder.Build();
                return root;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
