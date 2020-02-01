using SplitThatBill.Backend.Core.OwnedEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitThatBill.Backend.Core.Entities
{
    public class Person
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname { get => $"{Firstname} {Lastname}"; }
        public string ExternalId { get; private set; }
        public List<PersonBillItem> PersonBillItems { get; private set; }
        public List<PaymentDetail> PaymentDetails { get; private set; }
        public List<BillParticipant> Bills { get; private set; }
        public List<Bill> BillsTaken { get; private set; }

        private Person()
        {
            PersonBillItems = new List<PersonBillItem>();
            PaymentDetails = new List<PaymentDetail>();
            Bills = new List<BillParticipant>();
        }
        public Person(string firstname, string lastname) : this()
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public Person(int id, string firstname, string lastname) : this(firstname, lastname)
        {
            Id = id;
        }
        public void Update(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public void SetExternalId(string externalId)
        {
            ExternalId = externalId;
        }
        public decimal GetTotalPayable()
        {
            return PersonBillItems.Where(w => w.BillItem != null)
                .Aggregate(0.0M, (acc, personBill) => acc + (personBill.PayableUnitPrice *
                    personBill.BillItem.Bill.GetTotalChargeRates() + personBill.PayableUnitPrice));
        }
        public void AddBillItem(BillItem billItem, decimal payableUnitPrice)
        {
            PersonBillItems.Add(new PersonBillItem(this, billItem, payableUnitPrice));
        }
        public void RemoveBillItem(BillItem billItem)
        {
            RemoveBillItem(item => item.PersonId == Id && item.BillItemId == billItem.Id);
        }
        public void RemoveBillItem(int billItemId)
        {
            RemoveBillItem(item => item.PersonId == Id && item.BillItemId == billItemId);
        }
        public void RemoveBillItem(Predicate<PersonBillItem> filterExpression)
        {
            PersonBillItems.RemoveAll(filterExpression);
        }

        public void AddPaymentDetail(PaymentDetail paymentDetail)
        {
            PaymentDetails.Add(paymentDetail);
        }
        public void UpdatePaymentDetail(int id, PaymentDetail paymentDetail)
        {
            var paymentDetailToUpdate = PaymentDetails.FirstOrDefault(p => p.Id == id);

            if (null == paymentDetailToUpdate)
            {
                throw new NullReferenceException("The payment detail does not exist.");
            }

            paymentDetailToUpdate.Update(paymentDetail.BankName, paymentDetail.AccountNumber, paymentDetail.AccountName);
        }
        public void RemovePaymentDetail(int id)
        {
            RemovePaymentDetail(p => p.Id == id);
        }
        public void RemovePaymentDetail(Predicate<PaymentDetail> filterExpression)
        {
            PaymentDetails.RemoveAll(filterExpression);
        }
    }
}
