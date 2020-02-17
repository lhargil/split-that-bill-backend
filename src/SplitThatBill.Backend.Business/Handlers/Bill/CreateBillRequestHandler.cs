using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Business.Requests.Bills;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Bills
{
    public class CreateBillRequestHandler : IRequestHandler<CreateBillRequest, BillDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;
        private readonly IContextData _contextData;
        private readonly IExternalIdGenerator _externalIdGenerator;

        public CreateBillRequestHandler(SplitThatBillContext splitThatBillContext,
            IMapper mapper,
            IContextData contextData,
            IExternalIdGenerator externalIdGenerator)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
            _contextData = contextData;
            _externalIdGenerator = externalIdGenerator;
        }

        public async Task<BillDto> Handle(CreateBillRequest request, CancellationToken cancellationToken)
        {
            var billItems = request.BillFormModel.BillItems.Select(item =>
            {
                var billItem = new BillItem(item.BillItem.Description, item.BillItem.Amount);

                if (item.PersonId > 0)
                {
                    billItem.AssignPerson(item.PersonId, item.BillItem.Amount);
                }
                return billItem;
            }).ToList();
            var billToCreate = new Bill(request.BillFormModel.EstablishmentName, request.BillFormModel.BillDate, billItems, request.BillFormModel.Currency);
            billToCreate.Remarks = request.BillFormModel.Remarks;
            billToCreate.SetExternalId(_externalIdGenerator.Generate());


            billToCreate.SetBillItems(billItems);
            billToCreate.SetExtraCharges(request.BillFormModel.ExtraCharges.Select(item => new Core.OwnedEntities.ExtraCharge(item.Description, item.Rate)).ToList());

            request.BillFormModel.Participants.ForEach(participant =>
            {
                billToCreate.AddParticipant(participant.Person.Id);
            });

            _splitThatBillContext.Attach(_contextData.CurrentUser);
            billToCreate.UpdateBillTaker(_contextData.CurrentUser);

            _splitThatBillContext.Add(billToCreate);

            await _splitThatBillContext.SaveChangesAsync();

            return _mapper.Map<BillDto>(billToCreate);
        }
    }
}
