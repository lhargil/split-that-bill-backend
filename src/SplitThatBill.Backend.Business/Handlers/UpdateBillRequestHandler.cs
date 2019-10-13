﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.OwnedEntities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers
{
    public class UpdateBillRequestHandler : IRequestHandler<UpdateBillRequest, bool>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public UpdateBillRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBillRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .Include(i => i.ExtraCharges)
                .FirstOrDefaultAsync(b => b.Id == request.Id);

            if (null == bill)
            {
                throw new NullReferenceException("The bill to be updated does not exist.");
            }

            RemoveExtraCharges(bill, request.BillFormModel.ExtraCharges);
            RemoveBillItems(bill, request.BillFormModel.BillItems);
            bill.Update(request.BillFormModel.EstablishmentName,
                request.BillFormModel.BillDate,
                request.BillFormModel.BillItems.Select(item =>
                {
                    var billItem = bill.BillItems.Find(bi => bi.Id == item.Id);
                    if (billItem is object)
                    {
                        billItem.Update(item.Description, item.Amount);
                        return billItem;
                    }
                    return new BillItem(item.Description, item.Amount);
                }).ToList(),
                request.BillFormModel.ExtraCharges.Select(item =>
                {
                    var extraCharge = bill.ExtraCharges.Find(ec => ec.Id == item.Id);
                    if (extraCharge is object)
                    {
                        extraCharge.Update(item.Description, item.Rate);
                        return extraCharge;
                    }
                    return new ExtraCharge(item.Description, item.Rate);
                }).ToList());
            _splitThatBillContext.Entry(bill).State = EntityState.Modified;

            return await _splitThatBillContext.SaveChangesAsync() > 0;
        }

        private void RemoveExtraCharges(Bill bill, List<ExtraChargeFormModel> extraCharges)
        {
            var extraChargesToRemove = bill.ExtraCharges.Select(item => item.Id)
                .Except(extraCharges.Select(item => item.Id)).ToList();

            foreach (var ec in extraChargesToRemove)
            {
                bill.RemoveExtraCharge(ec);
            }
        }

        private void RemoveBillItems(Bill bill, List<BillItemFormModel> billItems)
        {
            var billItemsToRemove = bill.BillItems.Select(item => item.Id)
                .Except(billItems.Select(item => item.Id)).ToList();
            foreach (var bi in billItemsToRemove)
            {
                bill.RemoveBillItem(bi);
            }
        }
    }
}
