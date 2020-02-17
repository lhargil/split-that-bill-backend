using System;
using System.Collections.Generic;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillFormModel
    {
        private BillFormModel()
        {
            BillItems = new List<BillItemAssignmentFormModel>();
            ExtraCharges = new List<ExtraChargeFormModel>();
            Participants = new List<BillParticipantFormModel>();
        }
        public BillFormModel(int id, string establishmentName, DateTime billDate, string currency, string remarks) : this()
        {
            Id = id;
            EstablishmentName = establishmentName;
            BillDate = billDate;
            Remarks = remarks;
            Currency = currency;
        }
        public int Id { get; private set; }
        public string EstablishmentName { get; private set; }
        public DateTime BillDate { get; private set; }
        public string Remarks { get; set; }
        public List<BillItemAssignmentFormModel> BillItems { get; private set; }
        public List<ExtraChargeFormModel> ExtraCharges { get; private set; }
        public List<BillParticipantFormModel> Participants { get; private set; }
        public string Currency { get; private set; }
    }
}
