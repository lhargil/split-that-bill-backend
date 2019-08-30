﻿using SplitThatBill.Backend.Core.OwnedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitThatBill.Backend.Core.OwnedEntities
{
    public class ExtraCharge
    {
        public string Description { get; private set; }
        public decimal Rate { get; private set; }

        private ExtraCharge()
        {

        }

        public ExtraCharge(string description, decimal rate)
        {
            Description = description;
            Rate = rate;
        }
    }
}

namespace SplitThatBill.Backend.Core.Entities
{
    public class Bill
    {
        public int Id { get; private set; }
        public string EstablishmentName { get; private set; }
        public DateTime BillDate { get; private set; }
        public string Remarks { get; set; }
        public virtual List<BillItem> BillItems { get; private set; }
        public virtual List<PaymentDetail> PaymentDetails { get; private set; }
        public virtual List<ExtraCharge> ExtraCharges { get; private set; }
        private Bill()
        {
            BillItems = new List<BillItem>();
            PaymentDetails = new List<PaymentDetail>();
            ExtraCharges = new List<ExtraCharge>();
        }

        public Bill(string establishmentName, DateTime billDate): this()
        {
            EstablishmentName = establishmentName;
            BillDate = billDate;
        }

        public Bill(string establishmentName, DateTime billDate, List<BillItem> billItems)
        {
            EstablishmentName = establishmentName;
            BillDate = billDate;
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

        public int RemoveBillItem(int billId)
        {
            return RemoveBillItem(item => item.Id == billId);
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

        public int RemoveExtraCharge(string description)
        {
            return RemoveExtraCharge(extraCharge => extraCharge.Description == description);
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

    /*
     Quantity is always one. Multiple items in the receipt will be recorded n times where n = quantity in the receipt 
     */
    public class BillItem
    {
        public int Id { get; private set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int BillId { get; private set; }
        public virtual Bill Bill { get; private set; }
        public virtual List<PersonBillItem> PersonBillItems { get; private set; }
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
            var totalPayable = Bill.ExtraCharges.Aggregate(0.0M, (acc, charge) => {
                return UnitPrice + (UnitPrice * charge.Rate);
            });
            return totalPayable;
        }
    }

    public class Person
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname { get => $"{Firstname} {Lastname}"; }
        public virtual List<PersonBillItem> PersonBillItems { get; private set; }
        private Person()
        {
            PersonBillItems = new List<PersonBillItem>();
        }
    }

    public class PersonBillItem
    {
        public int PersonId { get; private set; }
        public virtual Person Person { get; private set; }
        public int BillItemId { get; private set; }
        public virtual BillItem BillItem { get; private set; }
        public decimal PayableUnitPrice { get; set; }
        private PersonBillItem()
        {

        }
    }

    public class PaymentDetail
    {
        public int Id { get; private set; }
        public string BankName { get; private set; }
        public string AccountNumber { get; private set; }
        public string AccountName { get; private set; }
        public int BillId { get; private set; }
        public virtual Bill Bill { get; private set; }
        private PaymentDetail()
        {

        }
    }
}