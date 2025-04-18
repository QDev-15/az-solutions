using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace AZ.Core
{
    public static class Helper
    {
        public static TimeZoneInfo GetTimeZone(string timeZoneId)
        {
            try
            {
                if (TZConvert.KnownIanaTimeZoneNames.Contains(timeZoneId))
                {
                    // Là IANA, chuyển sang Windows
                    var windowsId = TZConvert.IanaToWindows(timeZoneId);
                    return TimeZoneInfo.FindSystemTimeZoneById(windowsId);
                }
                else if (TZConvert.KnownWindowsTimeZoneIds.Contains(timeZoneId))
                {
                    // Là Windows timezone, dùng trực tiếp
                    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                }
                else
                {
                    throw new TimeZoneNotFoundException($"TimeZone '{timeZoneId}' không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi chuyển đổi timezone: {ex.Message}");
                return TimeZoneInfo.Local; // fallback nếu cần
            }
        }
    }
}
