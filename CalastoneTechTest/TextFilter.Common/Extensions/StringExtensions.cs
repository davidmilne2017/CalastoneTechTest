using System.Text.RegularExpressions;

namespace TextFilter.Common.Extensions
{
    public static class StringExtensions
    {
        public static string[] StringToWords(this string text)
        {
            //splits on non-chars with the exception of ' and - which can occur in the middle of words
            //hence extra logic to remove any leading or trailing ' and -
            return text.Split(" \t\r\n\x85\xA0.,;:!?()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Length > 1 && (w[0] == '\'' || w[0] == '-') ? w.Substring(1, w.Length - 1) : w)
                .Select(w => w.Length > 1 && (w[^1] == '\'' || w[^1] == '-') ? w.Substring(0, w.Length - 1) : w)
                .ToArray();
        }

        public static string MiddleLetters(this string word)
        {
            return word.Substring((int)Math.Ceiling(word.Length / 2.0) - 1, word.Length % 2 == 0 ? 2 : 1);
        }

        public static string CleanSpaces(this string text)
        {
            return Regex.Replace(text, @"\s+", " ").Trim();
        }

        public static string RemoveWord(this string text, string word)
        {
            return Regex.Replace(text, $@"(?<![a-zA-Z0-9]){word}(?![a-zA-Z0-9])", "");
        }

    }
}
