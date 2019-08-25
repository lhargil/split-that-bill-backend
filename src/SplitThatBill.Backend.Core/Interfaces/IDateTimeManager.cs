using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Core.Interfaces
{
    public interface IDateTimeManager
    {
        DateTime Today { get; }
    }
}
