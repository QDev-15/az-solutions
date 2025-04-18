using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core
{
    public static class DateTimeHelper
    {
        public static TimeZoneInfo defaultZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        public static DateTime ConvertUtcToLocal(DateTime utcTime, string timeZoneId)
        {
            if (string.IsNullOrEmpty(timeZoneId))
            {
                // Fallback nếu không có timezone => UTC+7
                timeZoneId = "SE Asia Standard Time";
            }

            try
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                // fallback nếu timezone sai
                var defaultZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, defaultZone);
            }
            catch (InvalidTimeZoneException)
            {
                var defaultZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, defaultZone);
            }
        }
        public static DateTime ConvertLocalToUtc(DateTime time, string timeZoneId)
        {
            if (string.IsNullOrEmpty(timeZoneId))
            {
                // Fallback nếu không có timezone => UTC+7
                timeZoneId = "SE Asia Standard Time";
            }
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            try
            {
                return TimeZoneInfo.ConvertTimeToUtc(time, timeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                // fallback nếu timezone sai
                return TimeZoneInfo.ConvertTimeToUtc(time, timeZone);
            }
            catch (InvalidTimeZoneException)
            {
                return TimeZoneInfo.ConvertTimeToUtc(time, timeZone);
            }
        }

        public static DateTime ConvertUtcToLocal(DateTime utcTime, TimeZoneInfo timeZone)
        {
            try
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                // fallback nếu timezone sai
                var defaultZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, defaultZone);
            }
            catch (InvalidTimeZoneException)
            {
                var defaultZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, defaultZone);
            }
        }

        public static DateTime ConvertLocalToUtc(DateTime time, TimeZoneInfo timeZone)
        {
            try
            {
                return TimeZoneInfo.ConvertTimeToUtc(time, timeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                // fallback nếu timezone sai
                return TimeZoneInfo.ConvertTimeToUtc(time, timeZone);
            }
            catch (InvalidTimeZoneException)
            {
                return TimeZoneInfo.ConvertTimeToUtc(time, timeZone);
            }
        }

    }
}
