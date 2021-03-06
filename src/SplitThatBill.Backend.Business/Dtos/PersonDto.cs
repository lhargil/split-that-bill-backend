﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonDto
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }
        public string ExternalId { get; set; }
        public PersonDto(int id, string firstname, string lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
        public List<PaymentDetailDto> PaymentDetails { get; set; }
        public PersonDto()
        {
            PaymentDetails = new List<PaymentDetailDto>();
        }
    }
}
