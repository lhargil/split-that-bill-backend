using System;
using System.Collections.Generic;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonFormModel
    {
        public PersonFormModel(int id, string firstname, string lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
    }

    public class PaymentDetailFormModel
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }

    public class PersonPaymentDetailsFormModel
    {
        public PersonFormModel Person { get; set; }
        public PaymentDetailFormModel PaymentDetail { get; set; }
    }
}
