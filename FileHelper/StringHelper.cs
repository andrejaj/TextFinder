using System.Text.RegularExpressions;

namespace FileHelper
{
    public static class StringHelper
    {
        public static int Occurence(this string s, string text)
        {
            return new Regex(@$"(?i){s}").Matches(text).Count;
        }
    }
}