using System;
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
        public string Description { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal? DiscountRate { get; set; }
        public int BillId { get; private set; }
        public Bill Bill { get; private set; }
        public List<PersonBillItem> PersonBillItems { get; private set; }
        private BillItem()
        {
            PersonBillItems = new List<PersonBillItem>();
        }

        public BillItem(string description, decimal unitPrice) : this()
        {
            Description = description;
            UnitPrice = unitPrice;
        }

        public BillItem(string description, decimal unitPrice, decimal? discountRate) : this(description, unitPrice)
        {
            DiscountRate = discountRate;
        }

        public void AssignPerson(int personId, decimal payableUnitPrice)
        {
            PersonBillItems.Add(new PersonBillItem(personId, this, payableUnitPrice));
        }

        public decimal GetTotalPayablePerItem()
        {
            var totalPayable = Bill.ExtraCharges.Aggregate(0.0M, (acc, charge) =>
            {
                var discountedUnitPrice = CalculateDiscountedUnitPrice(UnitPrice, DiscountRate);
                return discountedUnitPrice + (discountedUnitPrice * charge.Rate);
            });
            return totalPayable;
        }

        private decimal CalculateDiscountedUnitPrice(decimal unitPrice, decimal? discount)
        {
            return discount.HasValue ?
                unitPrice * discount.Value :
                unitPrice;
        }

        public void Update(string description, decimal unitPrice)
        {
            Update(description, unitPrice);
        }

        public void Update(string description, decimal unitPrice, decimal? discountRate)
        {
            Description = description;
            UnitPrice = unitPrice;
            DiscountRate = discountRate;
        }
    }
}
