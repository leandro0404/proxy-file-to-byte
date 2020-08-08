using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Example.FileToBite
{
    class Program
    {
        static async  Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            // link do pdf
            var url = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf";
            
            // chama servico 
            var service = serviceProvider.GetService<IDownload>();
            var data = await service.DownloadDataAsync(url);


            // vai salvar o arquivo  pdf na pasta   bin do projeto
            File.WriteAllBytes("hello.pdf", data);

            Console.WriteLine("Hello World!");
        }
    }
}