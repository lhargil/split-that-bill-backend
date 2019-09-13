using System;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Core.OwnedEntities
{
    public class ExtraCharge
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Rate { get; private set; }

        private ExtraCharge()
        {
        }

        public ExtraCharge(string description, decimal rate) : this()
        {
            Description = description;
            Rate = rate;
        }
    }
}
