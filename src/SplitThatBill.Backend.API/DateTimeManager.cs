using System;
using System.Globalization;
using NodaTime;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.API
{
    public class DateTimeManager : IDateTimeManager
    {
        public DateTimeManager()
        {
            Today = DateTime.UtcNow;
        }

        public DateTime Today { get; private set; }

        public string ConvertUTCToLocal(Instant instant)
        {
            var localDateTime = instant.InZone(DateTimeZoneProviders.Tzdb.GetSystemDefault()).LocalDateTime;
            return localDateTime.ToString("MMM dd, yyyy", (CultureInfo.CurrentCulture).DateTimeFormat);
        }
    }
}
