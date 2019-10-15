using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.ValueObjects;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillItemDto
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public Money UnitPrice { get; private set; }
        public decimal? Discount { get; set; }
        private BillItemDto() { }
        public BillItemDto(int id, string description, decimal amount, decimal? discount)
        {
            Id = id;
            Description = description;
            UnitPrice = new Money(amount);
            Discount = discount;
        }
    }
}
