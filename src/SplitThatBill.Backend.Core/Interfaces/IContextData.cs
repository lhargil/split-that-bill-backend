using System;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Core.Interfaces
{
    public interface IContextData
    {
        Person CurrentUser { get; set; }
    }
}
