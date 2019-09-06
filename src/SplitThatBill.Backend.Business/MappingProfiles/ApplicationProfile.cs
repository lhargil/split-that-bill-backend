using System;
using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.ValueObjects;

namespace SplitThatBill.Backend.Business.MappingProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<DateTime, string>().ConvertUsing(new DateTimeToStringConverter());
        }
    }

    public class DateTimeToStringConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("MMM d, yyyy");
        }
    }

    public class MoneyResolver : IValueResolver<BillItem, BillItemDto, Money>
    {
        public Money Resolve(BillItem source, BillItemDto destination, Money destMember, ResolutionContext context)
        {
            return new Money(source.UnitPrice);
        }
    }
}
