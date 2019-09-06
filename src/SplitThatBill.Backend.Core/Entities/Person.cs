using SplitThatBill.Backend.Core.OwnedEntities;
using System.Collections.Generic;

namespace SplitThatBill.Backend.Core.Entities
{
    public class Person
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname { get => $"{Firstname} {Lastname}"; }
        public List<PersonBillItem> PersonBillItems { get; private set; }
        public List<PaymentDetail> PaymentDetails { get; private set; }
        public Bill Bill { get; private set; }
        public int BillId { get; private set; }
        private Person()
        {
            PersonBillItems = new List<PersonBillItem>();
            PaymentDetails = new List<PaymentDetail>();
        }
        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
