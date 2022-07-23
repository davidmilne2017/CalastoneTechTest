using System.Text.RegularExpressions;

namespace TextFilter.Common.Extensions
{
    public static class StringExtensions
    {
        public static string[] StringToWords(this string text)
        {
            return text.Split(" \t\r\n\x85\xA0.,;:!?()-\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public static string MiddleLetters(this string word)
        {
            return word.Substring((int)Math.Ceiling(word.Length / 2.0) - 1, word.Length % 2 == 0 ? 2 : 1);
        }

        public static string CleanSpaces(this string text)
        {
            return Regex.Replace(text, @"\s+", " ").Trim();
        }

    }
}
