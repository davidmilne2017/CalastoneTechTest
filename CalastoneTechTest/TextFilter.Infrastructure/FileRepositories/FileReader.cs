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
                    throw new ArgumentException(Constants.NoPathProvidedError, nameof(path));

                if (!File.Exists(path))
                    throw new ArgumentException(Constants.FileNotFoundError, nameof(path));

                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using var bs = new BufferedStream(fs);
                using var sr = new StreamReader(bs, Encoding.UTF8);

                var builder = new StringBuilder();
                var line = "";
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    builder.AppendLine(line);
                }

                content = builder.ToString();
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
