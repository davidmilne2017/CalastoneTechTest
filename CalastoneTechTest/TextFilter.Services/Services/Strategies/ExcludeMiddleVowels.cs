using Microsoft.Extensions.Logging;
using TextFilter.Common;
using TextFilter.Common.Extensions;
using TextFilter.Common.Interfaces.Services.Strategies;

namespace TextFilter.Services.Services.Strategies
{
    public class ExcludeMiddleVowels : ITextFilterStrategy
    {

        private readonly ILogger<ExcludeMiddleVowels> _logger;

        public ExcludeMiddleVowels(ILogger<ExcludeMiddleVowels> logger)
        {
            _logger = logger;
        }

        public string FilterText(string text)
        {
            try
            {
                var vowels = new List<string> { "a", "e", "i", "o", "u" };
                var words = text.StringToWords();
                foreach (var word in words)
                {
                    var mid = word.MiddleLetters();
                    if (vowels.Any(v => word.MiddleLetters().ToLower().Contains(v)))
                        text = text.RemoveWord(word);
                }

                text = text.CleanSpaces();
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, Constants.MiddleVowelError);
            }

            return text;
        }
    }
}
