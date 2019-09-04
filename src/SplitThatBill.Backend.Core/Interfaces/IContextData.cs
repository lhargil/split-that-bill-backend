using System;
namespace SplitThatBill.Backend.Core.Interfaces
{
    public interface IContextData
    {
        string CurrentUser { get; set; }
    }
}
