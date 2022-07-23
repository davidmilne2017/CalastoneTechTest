using TextFilter.Common.Interfaces.Services;
using TextFilter.Common.Interfaces.Services.Strategies;

namespace TextFilter.Services.Services
{
    public class TextFilter : ITextFilter
    {

        private readonly IEnumerable<ITextFilterStrategy> _strategies;

        public TextFilter(IEnumerable<ITextFilterStrategy> strategies)
        {
            _strategies = strategies;
        }

        public string FilterText(string text)
        {
            foreach (var strategy in _strategies)
                text = strategy.FilterText(text);

            return text;
        }
    }
}
