﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Requests.Billings;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Billings
{
    public class UpdateBillingRequestHandler : IRequestHandler<UpdatePersonBillingRequest, int>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public UpdateBillingRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePersonBillingRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                .Include(i => i.PersonBillItems)
                .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person does not exist.");
            }

            var toRemove = person.PersonBillItems.Where(pbi => !request.PersonBilling.BillItems.Any(bi => bi.Id == pbi.BillItemId))
                .ToList();

            toRemove.ForEach(item =>
            {
                _splitThatBillContext.Entry(item).State = EntityState.Deleted;
            });

            request.PersonBilling.BillItems.ForEach(item =>
            {
                if (!person.PersonBillItems.Any(pb => pb.BillItemId == item.Id))
                {
                    var billItem = _mapper.Map<BillItem>(item);
                    _splitThatBillContext.Attach(billItem);
                    person.AddBillItem(billItem, item.Amount);
                }
            });

            return await _splitThatBillContext.SaveChangesAsync();
        }
    }
}
