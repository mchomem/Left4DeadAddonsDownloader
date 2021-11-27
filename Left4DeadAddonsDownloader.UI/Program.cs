using Left4DeadAddonsDownloader.Core.Models.Interfaces;
using Left4DeadAddonsDownloader.Core.Models.Repositories;
using Left4DeadAddonsDownloader.Core.Services;
using Left4DeadAddonsDownloader.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Left4DeadAddonsDownloader.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // https://docs.microsoft.com/en-us/answers/questions/277466/dependency-injection-in-windows-forms-and-ef-core.html
            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IExecutorService, ExecutorService>();
            services.AddScoped<IFileDownloadedRepository, FileDownloadedRepository>();
            services.AddScoped<IAppSettingsRepository, AppSettingsRepository>();
            services.AddScoped<MainForm>();
        }
    }
}
