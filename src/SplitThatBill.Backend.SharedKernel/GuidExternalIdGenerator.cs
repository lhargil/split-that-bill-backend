using System;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.SharedKernel
{
    public class GuidExternalIdGenerator : IExternalIdGenerator
    {
        public GuidExternalIdGenerator()
        {
        }

        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
