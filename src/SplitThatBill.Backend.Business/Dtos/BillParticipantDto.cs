using System;
namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillParticipantDto
    {
        public int Id { get; private set; }
        public PersonDto Person { get; private set; }
        private BillParticipantDto()
        {

        }
        public BillParticipantDto(int id, PersonDto person)
        {
            Id = id;
            Person = person;
        }
    }
}
