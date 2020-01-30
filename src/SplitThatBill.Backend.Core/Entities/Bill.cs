using SplitThatBill.Backend.Core.OwnedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitThatBill.Backend.Core.Entities
{
    public class Bill
    {
        public int Id { get; private set; }
        public string EstablishmentName { get; private set; }
        public DateTime BillDate { get; private set; }
        public string Remarks { get; set; }
        public List<BillItem> BillItems { get; private set; }
        public List<ExtraCharge> ExtraCharges { get; private set; }
        public List<BillParticipant> Participants { get; private set; }
        public int? BillTakerId { get; private set; }
        public Person BillTaker { get; private set; }
        public string ExternalId { get; private set; }

        private Bill()
        {
            BillItems = new List<BillItem>();
            ExtraCharges = new List<ExtraCharge>();
            Participants = new List<BillParticipant>();
        }

        public Bill(string establishmentName, DateTime billDate) : this()
        {
            EstablishmentName = establishmentName;
            BillDate = billDate;
        }

        public Bill(string establishmentName, DateTime billDate, List<BillItem> billItems) : this(establishmentName, billDate)
        {
            BillItems = billItems;
        }

        public void SetExternalId(string externalId)
        {
            ExternalId = externalId;
        }

        public void SetExtraCharges(List<ExtraCharge> extraCharges)
        {
            ExtraCharges = extraCharges;
        }

        public void SetBillItems(List<BillItem> billItems)
        {
            BillItems = billItems;
        }

        public void AddBillItem(BillItem billItem)
        {
            BillItems.Add(billItem);
        }

        public void Update(string establishmentName, DateTime billDate, List<BillItem> billItems, List<ExtraCharge> extraCharges)
        {
            EstablishmentName = establishmentName;
            BillDate = billDate;
            BillItems = billItems;
            ExtraCharges = extraCharges;
        }

        public void UpdateParticipants(List<BillParticipant> participants)
        {
            Participants = participants;
        }

        public void AddBillItem(string description, decimal unitPrice)
        {
            BillItems.Add(new BillItem(description, unitPrice));
        }

        public int RemoveBillItem(int billItemId)
        {
            return RemoveBillItem(item => item.Id == billItemId);
        }

        public int RemoveBillItem(Predicate<BillItem> filterExpression)
        {
            return BillItems.RemoveAll(filterExpression);
        }

        public void AddExtraCharge(ExtraCharge extraCharge)
        {
            ExtraCharges.Add(extraCharge);
        }

        public void AddExtraCharge(string description, decimal rate)
        {
            ExtraCharges.Add(new ExtraCharge(description, rate));
        }

        public int RemoveExtraCharge(int extraChargeId)
        {
            return RemoveExtraCharge(extraCharge => extraCharge.Id == extraChargeId);
        }

        public int RemoveExtraCharge(Predicate<ExtraCharge> filterExpression)
        {
            return ExtraCharges.RemoveAll(filterExpression);
        }

        public decimal GetBillTotal()
        {
            var totalCharges = GetTotalChargeRates();
            var totalBillAmountWithoutCharges = GetBillTotalWithoutCharges();
            return totalBillAmountWithoutCharges + (totalBillAmountWithoutCharges * totalCharges);
        }

        public decimal GetTotalChargeRates()
        {
            return ExtraCharges.Sum(s => s.Rate);
        }

        public decimal GetBillTotalWithoutCharges()
        {
            return BillItems.Aggregate(0.0M, (acc, bill) => acc + bill.UnitPrice);
        }

        public void AddParticipant(Person person)
        {
            Participants.Add(new BillParticipant(this, person));
        }

        public void AddParticipant(int personId)
        {
            Participants.Add(new BillParticipant(this, personId));
        }

        public void RemoveParticipant(Person person)
        {
            RemoveParticipant(person.Id);
        }

        public void RemoveParticipant(int personId)
        {
            RemoveParticipant(item => item.PersonId == personId && item.BillId == Id);
        }

        public void RemoveParticipant(Predicate<BillParticipant> filterExpression)
        {
            Participants.RemoveAll(filterExpression);
        }

        public void UpdateBillTaker(Person person)
        {
            BillTaker = person;
        }
    }
}
