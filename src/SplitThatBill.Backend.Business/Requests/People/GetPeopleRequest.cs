using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class GetPeopleRequest: IRequest<List<PersonDto>>
    {
    }
}
