using System;
namespace SplitThatBill.Backend.Business.Dtos
{
    public class ExtraChargeFormModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
