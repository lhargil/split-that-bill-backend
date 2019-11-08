using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.OwnedEntities;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class PaymentDetailProfile : Profile
    {
        public PaymentDetailProfile()
        {
            CreateMap<PaymentDetail, PaymentDetailDto>();
        }
    }
}
