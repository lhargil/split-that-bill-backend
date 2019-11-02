using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(m => m.TotalPayable, cfg => cfg.MapFrom(i => i.TotalPayable()));
        }
    }
}
