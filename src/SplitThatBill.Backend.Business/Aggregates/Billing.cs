using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Business.Aggregates
{
    public class Billing
    {
        public Billing(Bill bill, IMapper mapper)
        {
            TotalBillWithCharges = bill.GetBillTotal();
            TotalCharges = bill.GetTotalChargeRates();
            TotalBillWithoutCharges = bill.GetBillTotalWithoutCharges();

            var billItems = bill.BillItems.ToList();
            var personBillItems = billItems.SelectMany(bi => bi.PersonBillItems).ToList();
            BillItems = billItems.GroupJoin(personBillItems,
                l => l.Id,
                r => r.BillItemId,
                (l, r) => new { billItem = l, personBillItem = r.FirstOrDefault() })
                .Select(s => new PersonBillItemDto
                {
                    Id = s.personBillItem is object ? s.personBillItem.Id : 0,
                    Person = s.personBillItem is object ?
                        new PersonDto(s.personBillItem.Person.Id, s.personBillItem.Person.Firstname, s.personBillItem.Person.Lastname) :
                        null,
                    BillItem = new BillItemDto(s.billItem.Id, s.billItem.Description, s.billItem.UnitPrice, TotalCharges, s.billItem.DiscountRate)
                })
                .ToList();

            BillDto = new BillDto
            {
                Id = bill.Id,
                EstablishmentName = bill.EstablishmentName,
                Remarks = bill.Remarks,
                Participants = bill.Participants.Select(p => new BillParticipantDto(p.Id,
                        new PersonDto(p.Person.Id, p.Person.Firstname, p.Person.Lastname), personBillItems.Where(w => w.PersonId == p.PersonId).Aggregate(0.0M, (acc, curr) =>
                        {
                            return acc + (curr.PayableUnitPrice * bill.GetTotalChargeRates() + curr.PayableUnitPrice);
                        })
                    )).ToList(),
                BillTotal = bill.GetBillTotal(),
                BillTotalWithoutCharges = bill.GetBillTotalWithoutCharges(),
                TotalCharges = bill.GetTotalChargeRates()
            };
        }

        public decimal TotalBillWithCharges { get; private set; }
        public decimal TotalCharges { get; private set; }
        public decimal TotalBillWithoutCharges { get; private set; }
        public BillDto BillDto { get; private set; }
        public List<PersonBillItemDto> BillItems { get; private set; }

        public BillingDto ToDto()
        {
            return new BillingDto(BillDto, BillItems);
        }
    }
}
