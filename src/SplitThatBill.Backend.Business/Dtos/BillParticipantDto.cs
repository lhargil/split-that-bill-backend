using System;
using SplitThatBill.Backend.Core.ValueObjects;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillParticipantDto
    {
        public int Id { get; private set; }
        public PersonDto Person { get; private set; }
        public Money TotalPayable { get; private set; }
        private BillParticipantDto()
        {

        }
        public BillParticipantDto(int id, PersonDto person, decimal total)
        {
            Id = id;
            Person = person;
            TotalPayable = Money.Create(total);
        }
    }
}
