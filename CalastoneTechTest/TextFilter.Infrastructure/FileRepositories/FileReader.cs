using Microsoft.Extensions.Logging;
using System.Text;
using TextFilter.Common.Interfaces.FileRepositories;

namespace TextFilter.Infrastructure.FileRepositories
{
    public class FileReader : IFileReader
    {

        private readonly ILogger<FileReader> _logger;

        public const string NoPathProvidedError = "No path provided to ReadFileAsync!";
        public const string FileNotFoundError = "File not found!";

        public FileReader(ILogger<FileReader> logger)
        {
            _logger = logger;
        }

        public async Task<string> ReadFileAsync(string path)
        {

            //ToDo see if we can implement FileInfo
            var content = "";
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentException(nameof(path), NoPathProvidedError);

                if (!File.Exists(path))
                    throw new ArgumentException(nameof(path), FileNotFoundError);

                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using var sr = new StreamReader(fs, Encoding.UTF8);

                content = await sr.ReadToEndAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

            return content;


        }

        public string GetDefaultText()
        {
            return DefaultText.Alice;
        }
    }
}
