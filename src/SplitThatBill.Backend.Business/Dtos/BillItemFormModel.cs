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

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
