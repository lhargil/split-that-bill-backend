using System;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.API.Models
{
    public class RequestContextData : IContextData
    {
        public RequestContextData()
        {
        }

        public string CurrentUser { get; set; }
    }
}
