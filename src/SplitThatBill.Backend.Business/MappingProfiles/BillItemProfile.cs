using System;
using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class BillItemProfile : Profile
    {
        public BillItemProfile()
        {
            CreateMap<BillItem, BillItemDto>()
                .ForMember(m => m.UnitPrice, cfg => cfg.MapFrom<MoneyResolver>());
        }
    }
}
