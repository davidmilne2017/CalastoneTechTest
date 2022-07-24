using TextFilter.Common.Extensions;
using TextFilter.Common.Interfaces.Services.Strategies;

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
                    text = text.RemoveWord(word);
            }

            return text.CleanSpaces();
        }
    }
}
