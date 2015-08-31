using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SySTarjetas.Core.Common.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> EnumGetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T CastEnumByName<T>(this string enumName)
        {
            return (T)Enum.Parse(typeof(T), enumName, true);
        }

        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null) return string.Empty;

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes
                                                         (typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static T Value<T>(this Enum value)
        {
            return (T)Convert.ChangeType(value.GetType().GetField(value.ToString()).GetRawConstantValue(), typeof(T));
        }
    }
}
