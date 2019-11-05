using System.Collections.Generic;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillingDto
    {
        private BillingDto()
        {
            PeopleBilling = new List<PersonBillItemDto>();
        }
        public BillingDto(BillDto bill, List<PersonBillItemDto> peopleBilling) : this()
        {
            Bill = bill;
            PeopleBilling = peopleBilling;
        }
        public BillDto Bill { get; set; }
        public List<PersonBillItemDto> PeopleBilling { get; private set; }
    }
}
