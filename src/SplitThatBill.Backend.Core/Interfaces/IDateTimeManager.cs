using System;
using System.Collections.Generic;
using System.Text;
using NodaTime;

namespace SplitThatBill.Backend.Core.Interfaces
{
    public interface IDateTimeManager
    {
        DateTime Today { get; }
        string ConvertUTCToLocal(Instant instant);
    }
}
