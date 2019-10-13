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
                .ForMember(m => m.Remarks, cfg => cfg.NullSubstitute(string.Empty));
            CreateMap<BillFormModel, Bill>()
                .ForMember(m => m.Id, cfg => cfg.Ignore());
        }
    }
}
