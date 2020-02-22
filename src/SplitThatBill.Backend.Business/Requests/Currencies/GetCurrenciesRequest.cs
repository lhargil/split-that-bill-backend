using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Currencies
{
    public class GetCurrenciesRequest : IRequest<List<CurrencyDto>>
    {
        public GetCurrenciesRequest()
        {
        }
    }
}
