using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonDto
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname { get; private set; }
    }
}
