using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.FileToBite
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // build configuration
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("app-settings.json", false)
            .Build();
            services.AddSingleton(configuration);

            //services.AddScoped<IBlogAdapter, BlogAdapter>();

            services.AddHttpClient<IDownload, Download>();

            return services;
        }
    }
}