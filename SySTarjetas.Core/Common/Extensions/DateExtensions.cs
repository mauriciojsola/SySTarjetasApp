using System;
using System.Globalization;

namespace SySTarjetas.Core.Common.Extensions
{
    public static class DateExtensions
    {
        #region Extensiones para Meses

        public static DateTime Enero(this int year, int day)
        {
            return new DateTime(year, 1, day);
        }

        public static DateTime Febrero(this int year, int day)
        {
            return new DateTime(year, 2, day);
        }

        public static DateTime Marzo(this int year, int day)
        {
            return new DateTime(year, 3, day);
        }

        public static DateTime Abril(this int year, int day)
        {
            return new DateTime(year, 4, day);
        }

        public static DateTime Mayo(this int year, int day)
        {
            return new DateTime(year, 5, day);
        }

        public static DateTime Junio(this int year, int day)
        {
            return new DateTime(year, 6, day);
        }

        public static DateTime Julio(this int year, int day)
        {
            return new DateTime(year, 7, day);
        }

        public static DateTime Agosto(this int year, int day)
        {
            return new DateTime(year, 8, day);
        }

        public static DateTime Setiembre(this int year, int day)
        {
            return new DateTime(year, 9, day);
        }

        public static DateTime Octubre(this int year, int day)
        {
            return new DateTime(year, 10, day);
        }

        public static DateTime Noviembre(this int year, int day)
        {
            return new DateTime(year, 11, day);
        }

        public static DateTime Diciembre(this int year, int day)
        {
            return new DateTime(year, 12, day);
        } 

        public static bool EsIgualA(this DateTime unaFecha, DateTime otraFecha)
        {
            return unaFecha.Year == otraFecha.Year && unaFecha.Month == otraFecha.Month && unaFecha.Day == otraFecha.Day;
        }


        #endregion


        /// <summary>
        /// Gets a DateTime representing the first day in the current month
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns></returns>
        public static DateTime FirstMonthDay(this DateTime current)
        {
            var first = current.AddDays(1 - current.Day);
            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the first specified day in the current month
        /// </summary>
        /// <param name="current">The current day</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns></returns>
        public static DateTime FirstMonthDay(this DateTime current, DayOfWeek dayOfWeek)
        {
            var first = current.FirstMonthDay();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.NextDay(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the last day in the current month
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns></returns>
        public static DateTime LastMonthDay(this DateTime current)
        {
            var daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);

            var last = current.FirstMonthDay().AddDays(daysInMonth - 1);
            return last;
        }

        /// <summary>
        /// Gets a DateTime representing the last specified day in the current month
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns></returns>
        public static DateTime LastMonthDay(this DateTime current, DayOfWeek dayOfWeek)
        {
            var last = current.LastMonthDay();
            if (dayOfWeek == last.DayOfWeek) return last;
            last = dayOfWeek > last.DayOfWeek 
                ? last.AddDays((7 - (Math.Abs(dayOfWeek - last.DayOfWeek)))*-1) 
                : last.AddDays(Math.Abs(dayOfWeek - last.DayOfWeek) * -1);
            return last;
        }

        /// <summary>
        /// Gets a DateTime representing the first date following the current date
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns>The day following the current instance</returns>
        public static DateTime NextDay(this DateTime current)
        {
            return current.AddDays(1);
        }

        /// <summary>
        /// Gets a DateTime representing the first date following the current date which falls on the given day of the week
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="dayOfWeek">The day of week for the next date to get</param>
        public static DateTime NextDay(this DateTime current, DayOfWeek dayOfWeek)
        {
            var offsetDays = dayOfWeek - current.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            var result = current.AddDays(offsetDays);
            return result;
        }

        /// <summary>
        /// Gets a DateTime representing the first date prior to the current date which falls on the given day of the week
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="dayOfWeek">The day of week for the previous date to get</param>
        /// <param name="withinCurrentYear">Specifies if the returned date needs to stop in the first day of the year or go further back</param>
        /// <returns></returns>
        public static DateTime PrevDay(this DateTime current, DayOfWeek dayOfWeek, bool withinCurrentYear = false)
        {
            var offsetDays = current.DayOfWeek - dayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            var result = current.AddDays(-offsetDays);

            if (withinCurrentYear && result.Year < current.Year)
                result = result.AddDays((new DateTime(current.Year, 1, 1) - result).Days);

            return result;
        }

        /// <summary>
        /// Gets a number representing the week number to which the current date corresponds in the current culture calendar
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns>Returns an integer representing the week number</returns>
        public static int WeekNumber(this DateTime current)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            return currentCulture.Calendar.GetWeekOfYear(current, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday);
        }

        /// <summary>
        /// Gets the date of the first day of the first full week of the year
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="dayOfWeek">The day of week specified to be the first day of the week</param>
        /// <returns></returns>
        public static DateTime FirstDayFullWeekYear(this DateTime current, DayOfWeek dayOfWeek)
        {
            var januaryFirst = new DateTime(current.Year, 1, 1);
            return FirstMonthDay(januaryFirst, dayOfWeek);
        }

        public static string GetMonthName(this int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        public static DateTime EndOfDay(this DateTime day)
        {
            return day.AddDays(1).Subtract(TimeSpan.FromTicks(1));
        }
    }
}
