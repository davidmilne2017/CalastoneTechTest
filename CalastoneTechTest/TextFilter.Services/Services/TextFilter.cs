using TextFilter.Common.Interfaces.FileRepositories;
using TextFilter.Common.Interfaces.Services;
using TextFilter.Common.Interfaces.Services.Strategies;

namespace TextFilter.Services.Services
{
    public class TextFilter : ITextFilter
    {

        private readonly IFileReader _fileReader;
        private readonly IEnumerable<ITextFilterStrategy> _strategies;

        public TextFilter(IEnumerable<ITextFilterStrategy> strategies, IFileReader fileReader)
        {
            _strategies = strategies;
            _fileReader = fileReader;
        }

        public async Task<string> FilterText(string filename)
        {

            var text = "";
            if (string.IsNullOrEmpty(filename))
                text = _fileReader.GetDefaultText();
            else
                text = await _fileReader.ReadFileAsync(filename);

            foreach (var strategy in _strategies)
                text = strategy.FilterText(text);

            return text;
        }
    }
}
