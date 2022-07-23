using TextFilter.Common.Extensions;
using TextFilter.Common.Interfaces.Services;

namespace TextFilter.Services.Services.Strategies
{
    public class ExcludeMiddleVowels : ITextFilterStrategy
    {

        public string FilterText(string text)
        {
            var vowels = new List<string> { "a", "e", "i", "o", "u" };
            var words = text.StringToWords();
            foreach (var word in words)
            {
                var mid = word.MiddleLetters();
                if (vowels.Any(v => word.MiddleLetters().ToLower().Contains(v)))
                    text = text.Replace(word, "");
            }

            return text.CleanSpaces();
        }
    }
}
