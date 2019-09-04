using System;
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
    }
}
