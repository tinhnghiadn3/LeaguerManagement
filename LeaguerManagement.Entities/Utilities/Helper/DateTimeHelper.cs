using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.Utilities.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime ToDateTime(this long miniseconds)
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddMilliseconds(miniseconds);
        }

        public static List<DateTime> GenerateSaturday(int year)
        {
            var result = new List<DateTime>();

            for (var i = 1; i <= 12; i++)
            {
                var totalDaysOfMonth = DateTime.DaysInMonth(year, i);
                var firstDayOfMonth = new DateTime(year, i, 1);
                for (var j = 1; j <= totalDaysOfMonth; j++)
                {
                    if (firstDayOfMonth.AddDays(j).DayOfWeek == DayOfWeek.Saturday)
                        result.Add(new DateTime(year, i, j));
                }
            }

            return result;
        }

        public static List<DateTime> GenerateSunday(int year)
        {
            var result = new List<DateTime>();

            for (var i = 1; i <= 12; i++)
            {
                var totalDaysOfMonth = DateTime.DaysInMonth(year, i);
                var firstDayOfMonth = new DateTime(year, i, 1);

                for (var j = 1; j <= totalDaysOfMonth; j++)
                {
                    if (firstDayOfMonth.AddDays(j).DayOfWeek == DayOfWeek.Sunday)
                        result.Add(new DateTime(year, i, j));
                }
            }

            return result;
        }
    }
}
