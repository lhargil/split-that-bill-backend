using System;
namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonFormModel
    {
        public PersonFormModel(int id, string firstname, string lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
    }
}
