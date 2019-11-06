using System;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.API.Models
{
    public class RequestContextData : IContextData
    {
        public Person CurrentUser { get; set; }
    }
}
