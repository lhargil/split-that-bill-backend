using System;
namespace SplitThatBill.Backend.Business.Dtos
{
    public class ExtraChargeFormModel
    {
        public ExtraChargeFormModel(int id, string description, decimal rate)
        {
            Id = id;
            Description = description;
            Rate = rate;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Rate { get; private set; }
    }
}
