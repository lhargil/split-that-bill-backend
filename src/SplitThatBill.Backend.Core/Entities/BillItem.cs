using System.Collections.Generic;
using System.Linq;

namespace SplitThatBill.Backend.Core.Entities
{
    /*
     Quantity is always one. Multiple items in the receipt will be recorded n times where n = quantity in the receipt 
     */
    public class BillItem
    {
        public int Id { get; private set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int BillId { get; private set; }
        public Bill Bill { get; private set; }
        public List<PersonBillItem> PersonBillItems { get; private set; }
        private BillItem()
        {

        }

        public BillItem(string description, decimal unitPrice)
        {
            Description = description;
            UnitPrice = unitPrice;
        }

        public decimal GetTotalPayablePerItem()
        {
            var totalPayable = Bill.ExtraCharges.Aggregate(0.0M, (acc, charge) =>
            {
                return UnitPrice + (UnitPrice * charge.Rate);
            });
            return totalPayable;
        }
    }
}
