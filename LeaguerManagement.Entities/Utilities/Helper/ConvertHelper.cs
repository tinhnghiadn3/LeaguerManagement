using System;
using Newtonsoft.Json;

namespace LeaguerManagement.Entities.Utilities.Helper
{
    public static class ConvertHelper
    {
        public static long GetMiliSecond(this DateTime dateTime)
        {
            return (long)(dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public static decimal ToDecimal(this object input)
        {
            try
            {
                return Convert.ToDecimal(input);
            }
            catch
            {
                return 0;
            }
        }

        public static int ToInt(this object input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return 0;
            }
        }

        public static string ToString(this object input)
        {
            try
            {
                return Convert.ToString(input);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static decimal MathRound(this decimal input, int decimals = 0)
        {
            try
            {
                return Math.Round(input, decimals);
            }
            catch
            {
                return input;
            }
        }

        public static T JsonToObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static DateTime? ToDateTime(this string dateTime)
        {
            try
            {
                var result = DateTime.Parse(dateTime);

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ToRoman(this int number)
        {
            if ((number < 0) || (number > 3999)) return "NaN";
            if (number < 1) return "NaN";
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Chuyển đổi La Mã bị lỗi");
        }
    }
}
