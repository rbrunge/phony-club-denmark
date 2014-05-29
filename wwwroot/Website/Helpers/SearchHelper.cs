using System;
using System.Text;

namespace PhonyClubDenmark.Website.Helpers
{
    public static class SearchHelper
    {
        /// <summary>
        /// Used to make a user entered search string to a string to parse to Lucene.
        /// </summary>
        /// <param name="value">String to search for</param>
        /// <param name="allWords">If true, all keywords must be present.
        /// Default is false</param>
        /// <returns></returns>
        public static string ToLucene(this string value, bool allWords = false)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                return string.Empty;

            var returnValue = new StringBuilder();
            // split with null:
            // http://stackoverflow.com/questions/6111298/best-way-to-specify-whitespace-in-a-string-split-operation
            string[] split = value.Split(new[] {' ', '+', '-'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in split)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (allWords)
                    {
                        returnValue.AppendFormat("+{0}* ", item.Trim());
                    }
                    else
                    {
                        returnValue.AppendFormat("{0}* ", item.Trim());
                    }
                }
            }
            return returnValue.ToString();
        }
    }
}