namespace SplitThatBill.Backend.Business.Dtos
{
    public class PaymentDetailDto
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }
}
