using Microsoft.Extensions.Logging;
using TextFilter.Common;
using TextFilter.Common.Extensions;
using TextFilter.Common.Interfaces.Services.Strategies;

namespace TextFilter.Services.Services.Strategies
{
    public class FilterWordsLessThanThree : ITextFilterStrategy
    {

        private readonly ILogger<FilterWordsLessThanThree> _logger;

        public FilterWordsLessThanThree(ILogger<FilterWordsLessThanThree> logger)
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
                    if (word.Length < 3)
                        text = text.RemoveWord(word);
                }

                text = text.CleanSpaces();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, Constants.LessThanThreeError);
            }

            return text;
        }
    }
}
