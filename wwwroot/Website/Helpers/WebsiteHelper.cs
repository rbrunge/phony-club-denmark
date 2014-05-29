using System;
using System.Reflection;

namespace PhonyClubDenmark.Website.Helpers
{
    public static class WebsiteHelper
    {

        public static class CoreAssembly
        {
            public static readonly Assembly Reference = typeof(CoreAssembly).Assembly;
            public static readonly Version Version = Reference.GetName().Version;
        }
        /// <summary>
        /// Returns current assembly version
        /// </summary>
        /// <returns></returns>
        public static string GetVersion()
        {
            string version = CoreAssembly.Version.ToString();
            return version;
        }

        /// <summary>
        /// Shortens a string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <param name="stopAtLineBreak"></param>
        /// <returns></returns>
        public static string ToShortenString(this string value, int length = 200, bool stopAtLineBreak = false)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (stopAtLineBreak)
            {
                var index = value.IndexOf('\n');
                if (index != -1)
                {
                    value = value.Substring(0, index - 1);
                }
            }

            if (value.Length > length + 3)
            {
                return value.Substring(0, length) + " ...";
            }

            return value;
        }

    }
}