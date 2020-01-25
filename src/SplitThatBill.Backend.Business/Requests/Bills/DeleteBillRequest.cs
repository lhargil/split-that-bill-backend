using System;
using MediatR;

namespace SplitThatBill.Backend.Business.Requests.Bills
{
    public class DeleteBillRequest : IRequest<bool>
    {
        public DeleteBillRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
