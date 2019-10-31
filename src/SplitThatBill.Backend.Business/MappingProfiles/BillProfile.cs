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
                .ForMember(m => m.Remarks, cfg => cfg.NullSubstitute(string.Empty))
                .ForMember(m => m.BillTotal, cfg => cfg.MapFrom(item => item.GetBillTotal()))
                .ForMember(m => m.BillTotalWithoutCharges, cfg => cfg.MapFrom(item => item.GetBillTotalWithoutCharges()))
                .ForMember(m => m.TotalCharges, cfg => cfg.MapFrom(item => item.GetTotalChargeRates()));
        }
    }
}
