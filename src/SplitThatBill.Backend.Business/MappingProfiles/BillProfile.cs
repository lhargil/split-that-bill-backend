using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<Bill, BillDto>()
                .ForMember(m => m.Id, cfg => cfg.MapFrom(f => f.Id))
                .ForMember(m => m.EstablishmentName, cfg => cfg.MapFrom(f => f.EstablishmentName))
                .ForMember(m => m.BillDate, cfg => cfg.MapFrom(f => f.BillDate))
                .ForMember(m => m.Remarks, cfg => cfg.NullSubstitute(string.Empty));
        }
    }
}
