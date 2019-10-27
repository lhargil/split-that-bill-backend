namespace SplitThatBill.Backend.Core.Entities
{
    public class BillParticipant
    {
        public int Id { get; private set; }
        public int BillId { get; private set; }
        public Bill Bill { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        private BillParticipant()
        { }

        public BillParticipant(Bill bill, Person person)
        {
            Bill = bill;
            Person = person;
        }

        public BillParticipant(Bill bill, int personId)
        {
            Bill = bill;
            PersonId = personId;
        }
    }
}
