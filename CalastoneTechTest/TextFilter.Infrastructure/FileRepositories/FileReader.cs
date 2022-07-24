using Microsoft.Extensions.Logging;
using System.Text;
using TextFilter.Common;
using TextFilter.Common.Interfaces.FileRepositories;

namespace TextFilter.Infrastructure.FileRepositories
{
    public class FileReader : IFileReader
    {

        private readonly ILogger<FileReader> _logger;

        public FileReader(ILogger<FileReader> logger)
        {
            _logger = logger;
        }

        public async Task<string> ReadFileAsync(string path)
        {
            var content = "";
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentException(nameof(path), Constants.NoPathProvidedError);

                if (!File.Exists(path))
                    throw new ArgumentException(nameof(path), Constants.FileNotFoundError);

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
