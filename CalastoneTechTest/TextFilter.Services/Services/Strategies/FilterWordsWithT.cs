using Microsoft.Extensions.Logging;
using TextFilter.Common;
using TextFilter.Common.Extensions;
using TextFilter.Common.Interfaces.Services.Strategies;

namespace TextFilter.Services.Services.Strategies
{
    public class FilterWordsWithT : ITextFilterStrategy
    {

        private readonly ILogger<FilterWordsWithT> _logger;

        public FilterWordsWithT(ILogger<FilterWordsWithT> logger)
        {
            _logger = logger;
        }

        public string FilterText(string text)
        {
            try
            {
                var words = text.StringToWords();
                foreach (var word in words)
                {
                    if (word.ToLower().Contains('t'))
                        text = text.RemoveWord(word);
                }

                text = text.CleanSpaces();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.WithTError);
            }

            return text;
        }
    }
}
