namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillItemFormModel
    {
        public BillItemFormModel(int id, string description, decimal amount)
        {
            Description = description;
            Amount = amount;
            Id = id;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public decimal? Discount { get; set; }
    }
}
