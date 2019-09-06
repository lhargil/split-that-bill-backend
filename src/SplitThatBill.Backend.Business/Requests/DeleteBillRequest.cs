using System;
using MediatR;

namespace SplitThatBill.Backend.Business.Requests
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
