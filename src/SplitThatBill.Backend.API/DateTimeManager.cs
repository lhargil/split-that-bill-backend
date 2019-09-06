using System;
using NodaTime;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.API
{
    public class DateTimeManager : IDateTimeManager
    {
        public DateTimeManager()
        {
            var zonedDateTime = new ZonedDateTime(Instant.FromDateTimeUtc(DateTime.UtcNow), DateTimeZone.Utc);
            Today = zonedDateTime.ToDateTimeUtc();
        }

        public DateTime Today { get; private set; }
    }
}
