using TextFilter.Common.Interfaces.Services.Outputters;

namespace TextFilter.Services.Services.Outputters
{
    public class ConsoleOutputter : IOutputter
    {
        public void OutputText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
