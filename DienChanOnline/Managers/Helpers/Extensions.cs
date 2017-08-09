using System;
using System.Globalization;
using System.Net;

namespace DienChanOnline.Managers.Helpers
{
    public static class Extensions
    {
        public static string Translate(this string text, string languagePair)
        {
            var url = $"http://www.google.com/translate_t?hl=en&ie=UTF8&text={text}&langpair={languagePair}";

            var webClient = new WebClient {Encoding = System.Text.Encoding.UTF8};

            var result = webClient.DownloadString(url);

            result = result.Substring(result.IndexOf("<span title=\"", StringComparison.Ordinal) + "<span title=\"".Length);

            result = result.Substring(result.IndexOf(">", StringComparison.Ordinal) + 1);

            result = result.Substring(0, result.IndexOf("</span>", StringComparison.Ordinal));

            return result.Trim().ToTitleCase();
        }

        public static string ToTitleCase(this string text)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(text);
        }
    }
}