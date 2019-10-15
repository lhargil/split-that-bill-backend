using System;
using System.Text;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonDto
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname { get; private set; }
        public PersonDto(int id, string firstname, string lastname, string fullname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Fullname = fullname;
        }
    }
}
