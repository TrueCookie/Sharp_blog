using System;
using System.Configuration;

namespace Sharp_blog
{
    public static class Extensions
    {
        public static string ToConfigLocalTime(this DateTime utcDt)
        {
            var configTz = TimeZoneInfo.FindSystemTimeZoneById(
                ConfigurationManager.AppSettings["Timezone"]);

            return String.Format("{0}, ({1})",
                TimeZoneInfo.
                    ConvertTimeToUtc(utcDt, configTz).ToShortDateString(),
                ConfigurationManager.AppSettings["TimezoneAbbr"]);
        }
    }
}