namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonBillItemDto
    {
        public int Id { get; set; }
        public PersonDto Person { get; set; }
        public BillItemDto BillItem { get; set; }
    }
}
