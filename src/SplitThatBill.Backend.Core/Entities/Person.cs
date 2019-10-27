using SplitThatBill.Backend.Core.OwnedEntities;
using System;
using System.Collections.Generic;

namespace SplitThatBill.Backend.Core.Entities
{
    public class Person
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname { get => $"{Firstname} {Lastname}"; }
        public Bill Bill { get; private set; }
        public int? BillId { get; private set; }
        public List<PersonBillItem> PersonBillItems { get; private set; }
        public List<PaymentDetail> PaymentDetails { get; private set; }
        public List<BillParticipant> Participants { get; private set; }

        private Person()
        {
            PersonBillItems = new List<PersonBillItem>();
            PaymentDetails = new List<PaymentDetail>();
            Participants = new List<BillParticipant>();
        }
        public Person(string firstname, string lastname) : this()
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public void Update(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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
    }
}
