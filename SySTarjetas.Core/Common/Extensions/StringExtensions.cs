using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SySTarjetas.Core.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return String.IsNullOrWhiteSpace(text);
        }

        public static bool ContainsSpaces(this string text)
        {
            const string regex = @"\s+";
            var isMatch = Regex.IsMatch(text, regex);
            return isMatch;
        }

        public static string RemoveAllSpaces(this string text)
        {
            var value = text;
            value = value.Replace(" ", string.Empty);
            return value;
        }

        public static string FromHtmlToPlainText(this string text)
        {
            var value = text;
            value = value.Replace("<br>", Environment.NewLine);
            value = value.Replace("<br />", Environment.NewLine);
            return value;
        }

        public static string ToNoReply(this string emailAddress)
        {
            var domain = emailAddress.Substring(emailAddress.IndexOf('@'));
            return string.Format("no-reply{0}", domain);
        }

        /// <summary>
        /// Extracts the domain from an email address:
        /// admin@ticketprinting.com -> domain: ticketprinting.com
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        //public static string EmailDomain(this string emailAddress)
        //{
        //    if (!ValidationUtility.IsValidEmail(emailAddress)) return string.Empty;
        //    var domain = emailAddress.Substring(emailAddress.LastIndexOf('@') + 1);
        //    return domain;
        //}

        public static string TrimOrNullIfEmpty(this string s)
        {
            return String.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }

        public static decimal? ToDecimalOrNullIfEmpty(this string s)
        {
            var trimmedString = s.TrimOrNullIfEmpty();
            decimal result;
            if (Decimal.TryParse(trimmedString, out result)) return result;
            return null;
        }

        public static decimal ToDecimalOrZeroIfEmpty(this string s)
        {
            return s.ToDecimalOrNullIfEmpty() ?? 0.0m;
        }

        public static decimal ToDecimalOrValueIfEmpty(this string s, decimal value)
        {
            return s.ToDecimalOrNullIfEmpty() ?? value;
        }

        public static double? ToDoubleOrNullIfEmpty(this string s)
        {
            var trimmedString = s.TrimOrNullIfEmpty();
            double result;
            if (Double.TryParse(trimmedString, out result)) return result;
            return null;
        }

        public static double ToDoubleOrZeroIfEmpty(this string s)
        {
            return s.ToDoubleOrNullIfEmpty() ?? 0.0D;
        }

        public static double ToDoubleOrValueIfEmpty(this string s, double value)
        {
            return s.ToDoubleOrNullIfEmpty() ?? value;
        }

        public static int? ToIntOrNullIfEmpty(this string s)
        {
            var trimmedString = s.TrimOrNullIfEmpty();
            int result;
            if (Int32.TryParse(trimmedString, out result)) return result;
            return null;
        }

        public static int ToIntOrZeroIfEmpty(this string s)
        {
            return s.ToIntOrNullIfEmpty() ?? 0;
        }

        public static int ToIntOrValueIfEmpty(this string s, int value)
        {
            return s.ToIntOrNullIfEmpty() ?? value;
        }

        public static bool ToBoolean(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            return Boolean.Parse(s);
        }

        public static string Coalesce(this string str, params string[] strings)
        {
            return (new[] { str })
                .Concat(strings)
                .FirstOrDefault(s => !string.IsNullOrEmpty(s));
        }

        public static string Truncate(this string value, int maxLength, bool includeEllipsis = false, string overrideEllipsis = "")
        {
            return value.Length <= maxLength
                ? value
                : (includeEllipsis
                    ? string.Format("{0}{1}", value.Substring(0, maxLength - 1),
                        String.IsNullOrWhiteSpace(overrideEllipsis) ? "&hellip;" : overrideEllipsis)
                    : value.Substring(0, maxLength));
        }

        public static string TruncateInsideOut(this string value, int maxLength, bool includeEllipsis = true, string overrideEllipsis = "")
        {
            if (value.Length <= maxLength) return value;

            var beginLength = (int)(maxLength / 2);
            var endLength = maxLength - beginLength;


            return (includeEllipsis
                    ? string.Format("{0}{1}{2}", value.Substring(0, beginLength - 1),
                        String.IsNullOrWhiteSpace(overrideEllipsis) ? "&hellip;" : overrideEllipsis,
                        value.Substring(value.Length - endLength, endLength))
                    : value.Substring(0, maxLength));
        }

        public static IEnumerable<string> GetLines(this string value, bool removeEmpty = true,
            params string[] separators)
        {
            return string.IsNullOrEmpty(value)
                ? new List<string>()
                : value.Split(separators ?? new[] { Environment.NewLine },
                    removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None).Select(x => x.Trim());
        }
    }
}
