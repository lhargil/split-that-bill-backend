using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.Currencies;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Currencies
{
    public class GetCurrenciesRequestHandler : IRequestHandler<GetCurrenciesRequest, List<CurrencyDto>>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public GetCurrenciesRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<List<CurrencyDto>> Handle(GetCurrenciesRequest request, CancellationToken cancellationToken)
        {
            var currencies = await _splitThatBillContext.Currencies
                .Select(s => new CurrencyDto
                {
                    Code = s.Code,
                    Name = s.Name
                }).ToListAsync();

            return currencies;
        }
    }
}
