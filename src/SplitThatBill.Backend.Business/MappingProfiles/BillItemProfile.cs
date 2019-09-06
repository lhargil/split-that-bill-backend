using System;
using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;
using static SplitThatBill.Backend.Business.Dtos.BillFormModel;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class BillItemProfile : Profile
    {
        public BillItemProfile()
        {
            CreateMap<BillItem, BillItemDto>()
                .ForMember(m => m.UnitPrice, cfg => cfg.MapFrom<MoneyResolver>());
            CreateMap<BillItemFormModel, BillItem>()
                .ForMember(m => m.UnitPrice, cfg => cfg.MapFrom(item => item.Amount));
        }
    }
}
