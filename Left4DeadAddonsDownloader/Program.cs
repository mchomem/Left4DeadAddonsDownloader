using Left4DeadAddonsDownloader.Models.Interfaces;
using Left4DeadAddonsDownloader.Models.Repositories;
using Left4DeadAddonsDownloader.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Left4DeadAddonsDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var executorService = serviceProvider.GetService<IExecutorService>();
            executorService.Start();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IExecutorService, ExecutorService>();
            services.AddScoped<IFileDownloadedRepository, FileDownloadedRepository>();
        }
    }
}
