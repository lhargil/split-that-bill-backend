using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Core.OwnedEntities
{
    public class PaymentDetail
    {
        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; set; }
        public string BankName { get; private set; }
        public string AccountNumber { get; private set; }
        public string AccountName { get; private set; }
        private PaymentDetail()
        {

        }
        public PaymentDetail(string bankName, string accountNumber, string accountName)
        {
            BankName = bankName;
            AccountNumber = accountNumber;
            AccountName = accountName;
        }
    }
}
