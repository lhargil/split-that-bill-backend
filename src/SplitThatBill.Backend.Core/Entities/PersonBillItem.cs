namespace SplitThatBill.Backend.Core.Entities
{
    public class PersonBillItem
    {
        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public int BillItemId { get; private set; }
        public BillItem BillItem { get; private set; }
        public decimal PayableUnitPrice { get; set; }
        private PersonBillItem()
        {

        }
        public PersonBillItem(Person person, BillItem billItem, decimal payableUnitPrice)
        {
            Person = person;
            BillItem = billItem;
            PayableUnitPrice = payableUnitPrice;
        }
        public PersonBillItem(int personId, int billItemId, decimal payableUnitPrice)
        {
            PersonId = personId;
            BillItemId = billItemId;
            PayableUnitPrice = payableUnitPrice;
        }
        public PersonBillItem(int personId, BillItem billItem, decimal payableUnitPrice)
        {
            PersonId = personId;
            BillItem = billItem;
            PayableUnitPrice = payableUnitPrice;
        }
        public void Update(Person person, BillItem billItem, decimal payableUnitPrice)
        {
            Person = person;
            BillItem = billItem;
            PayableUnitPrice = payableUnitPrice;
        }
        public void Update(decimal payableUnitPrice)
        {
            PayableUnitPrice = payableUnitPrice;
        }
    }
}
