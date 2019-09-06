namespace SplitThatBill.Backend.Core.Entities
{
    public class PersonBillItem
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public int BillItemId { get; private set; }
        public BillItem BillItem { get; private set; }
        public decimal PayableUnitPrice { get; set; }
        private PersonBillItem()
        {

        }
    }
}
