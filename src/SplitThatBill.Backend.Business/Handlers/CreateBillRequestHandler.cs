using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers
{
    public class CreateBillRequestHandler : IRequestHandler<CreateBillRequest, BillDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;
        private readonly IContextData _contextData;

        public CreateBillRequestHandler(SplitThatBillContext splitThatBillContext,
            IMapper mapper,
            IContextData contextData)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
            _contextData = contextData;
        }

        public async Task<BillDto> Handle(CreateBillRequest request, CancellationToken cancellationToken)
        {
            var billToCreate = new Bill(request.BillFormModel.EstablishmentName, request.BillFormModel.BillDate, null);
            billToCreate.Remarks = request.BillFormModel.Remarks;
            billToCreate.SetBillItems(request.BillFormModel.BillItems.Select(item => new BillItem(item.Description, item.Amount)).ToList());
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
