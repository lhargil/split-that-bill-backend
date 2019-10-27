using System;
using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class BillParticipantProfile : Profile
    {
        public BillParticipantProfile()
        {
            CreateMap<BillParticipant, BillParticipantDto>();
        }
    }
}
