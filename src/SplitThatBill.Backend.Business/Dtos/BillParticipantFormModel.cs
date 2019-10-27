using System;
namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillParticipantFormModel
    {
        public BillParticipantFormModel()
        {
        }
        public int Id { get; set; }
        public PersonFormModel Person { get; set; }
    }
}
