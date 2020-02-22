using System;
namespace SplitThatBill.Backend.Core.Entities
{
    public class Currency
    {
        public Currency()
        {
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
