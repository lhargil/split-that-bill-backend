using System.Collections.Generic;
using System.Linq;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonBillItemsDto
    {
        public PersonDto Person { get; private set; }
        public List<BillItemDto> Bills { get; private set; }
        private PersonBillItemsDto()
        {
            Bills = new List<BillItemDto>();
        }
        public PersonBillItemsDto(Person person) : this()
        {
            Person = new PersonDto(person.Id, person.Firstname, person.Lastname, person.Fullname);
            Bills.AddRange(person.PersonBillItems.Select(item => new BillItemDto(item.BillItem.Id,
                item.BillItem.Description,
                item.BillItem.UnitPrice,
                item.BillItem.DiscountRate))
                .ToList());
        }
    }
}
