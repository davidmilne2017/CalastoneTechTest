using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TextFilter.Common.Interfaces.FileRepositories;
using TextFilter.Common.Interfaces.Services;
using TextFilter.Common.Interfaces.Services.Outputters;
using TextFilter.Common.Interfaces.Services.Strategies;
using TextFilter.Infrastructure.FileRepositories;
using TextFilter.Services.Services.Outputters;
using TextFilter.Services.Services.Strategies;

namespace CalastoneTechTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            using IHost host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
                   services.AddTransient<IFileReader, FileReader>()
                   .AddTransient<ITextFilterStrategy, ExcludeMiddleVowels>()
                   .AddTransient<ITextFilterStrategy, FilterWordsLessThanThree>()
                   .AddTransient<ITextFilterStrategy, FilterWordsWithT>()
                   .AddTransient<ITextFilter, TextFilter.Services.Services.TextFilter>()
                   .AddTransient<IOutputter, ConsoleOutputter>()
                   )
               .ConfigureLogging((_, logging) =>
               {
                   logging.ClearProviders();
                   logging.AddSimpleConsole(options => options.IncludeScopes = true);
                   logging.AddEventLog();
               })
               .Build();

            Console.WriteLine("Please enter a file path to filter; or just press enter to run on default Alice in Wonderland text");
            var fileName = Console.ReadLine();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var textFilter = provider.GetRequiredService<ITextFilter>();
            textFilter.FilterText(fileName).GetAwaiter().GetResult();
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}