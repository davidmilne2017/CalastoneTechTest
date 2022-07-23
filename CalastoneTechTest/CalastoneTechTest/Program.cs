using Microsoft.Extensions.Hosting;

namespace CalastoneTechTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
               //.ConfigureServices((_, services) =>
               //    services.AddSingleton<HttpClient>()
               //        .AddTransient<IWebCrawler, Services.WebCrawler>()
               //        .AddTransient<IPageScanner, PageScanner>()
               //        .AddTransient<ILinkPrinter, ConsolePrinter>())
               .Build();


            //using IServiceScope serviceScope = host.Services.CreateScope();
            //IServiceProvider provider = serviceScope.ServiceProvider;
            //var webCrawler = provider.GetRequiredService<IWebCrawler>();
        }
    }
}