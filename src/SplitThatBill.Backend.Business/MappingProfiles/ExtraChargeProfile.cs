using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.OwnedEntities;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class ExtraChargeProfile : Profile
    {
        public ExtraChargeProfile()
        {
            CreateMap<ExtraCharge, ExtraChargeDto>();
        }
    }
}
