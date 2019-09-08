using SplitThatBill.Backend.Core.OwnedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitThatBill.Backend.Core.Entities
{
    public class Bill
    {
        public int Id { get; private set; }
        public string EstablishmentName { get; private set; }
        public DateTime BillDate { get; private set; }
        public string Remarks { get; set; }
        public List<BillItem> BillItems { get; private set; }
        public List<ExtraCharge> ExtraCharges { get; private set; }
        public Person BillTaker { get; private set; }

        private Bill()
        {
            BillItems = new List<BillItem>();
            ExtraCharges = new List<ExtraCharge>();
        }

        public Bill(string establishmentName, DateTime billDate, Person billTaker) : this()
        {
            EstablishmentName = establishmentName;
            BillDate = billDate;
            BillTaker = billTaker;
        }

        public Bill(string establishmentName, DateTime billDate, Person billTaker, List<BillItem> billItems) : this(establishmentName, billDate, billTaker)
        {
            BillItems = billItems;
        }

        public void AddBillItem(BillItem billItem)
        {
            BillItems.Add(billItem);
        }

        public void AddBillItem(string description, decimal unitPrice)
        {
            BillItems.Add(new BillItem(description, unitPrice));
        }

        public int RemoveBillItem(int billItemId)
        {
            return RemoveBillItem(item => item.Id == billItemId);
        }

        public int RemoveBillItem(Predicate<BillItem> filterExpression)
        {
            return BillItems.RemoveAll(filterExpression);
        }

        public void AddExtraCharge(ExtraCharge extraCharge)
        {
            ExtraCharges.Add(extraCharge);
        }

        public void AddExtraCharge(string description, decimal rate)
        {
            ExtraCharges.Add(new ExtraCharge(description, rate));
        }

        public int RemoveExtraCharge(int extraChargeId)
        {
            return RemoveExtraCharge(extraCharge => extraCharge.Id == extraChargeId);
        }

        public int RemoveExtraCharge(Predicate<ExtraCharge> filterExpression)
        {
            return ExtraCharges.RemoveAll(filterExpression);
        }

        public decimal GetBillTotal()
        {
            var totalCharges = ExtraCharges.Sum(c => c.Rate);
            var totalBillAmountWithoutCharges = BillItems.Aggregate(0.0M, (acc, bill) => acc + bill.UnitPrice);
            var totalBillAmount = totalBillAmountWithoutCharges + (totalBillAmountWithoutCharges * totalCharges);

            return totalBillAmount;
        }
    }
}
