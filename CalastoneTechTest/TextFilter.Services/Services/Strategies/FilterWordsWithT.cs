using TextFilter.Common.Extensions;
using TextFilter.Common.Interfaces.Services;

namespace TextFilter.Services.Services.Strategies
{
    public class FilterWordsWithT : ITextFilterStrategy
    {
        public string FilterText(string text)
        {
            var words = text.StringToWords();
            foreach (var word in words)
            {
                if (word.ToLower().Contains('t'))
                    text = text.Replace(word, "");
            }

            return text.CleanSpaces();
        }
    }
}
