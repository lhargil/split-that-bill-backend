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
        public Person BillTaker { get; set; }

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

        public void SetExtraCharges(List<ExtraCharge> extraCharges)
        {
            ExtraCharges = extraCharges;
        }

        public void SetBillItems(List<BillItem> billItems)
        {
            BillItems = billItems;
        }

        public void AddBillItem(BillItem billItem)
        {
            BillItems.Add(billItem);
        }

        public void Update(string establishmentName, DateTime billDate, List<BillItem> billItems, List<ExtraCharge> extraCharges)
        {
            EstablishmentName = establishmentName;
            BillDate = billDate;
            BillItems = billItems;
            ExtraCharges = extraCharges;
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

        public void UpdateCharge(ExtraCharge extraCharge)
        {
            var charge = ExtraCharges.Find(ec => ec.Id == extraCharge.Id);
            if (charge is object)
            {
                charge.Description = extraCharge.Description;
                charge.Rate = extraCharge.Rate;
            }
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
            var totalCharges = GetTotalCharges();
            var totalBillAmountWithoutCharges = BillItems.Aggregate(0.0M, (acc, bill) => acc + bill.UnitPrice);
            var totalBillAmount = totalBillAmountWithoutCharges + (totalBillAmountWithoutCharges * totalCharges);

            return totalBillAmount;
        }

        public decimal GetTotalCharges()
        {
            return ExtraCharges.Sum(s => s.Rate);
        }
    }
}
