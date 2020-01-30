using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillDto
    {
        public int Id { get; set; }
        public string EstablishmentName { get; set; }
        public string BillDate { get; set; }
        public string Remarks { get; set; }
        public string ExternalId { get; set; }
        public List<BillItemDto> BillItems { get; set; }
        public List<ExtraChargeDto> ExtraCharges { get; set; }
        public List<BillParticipantDto> Participants { get; set; }
        public decimal BillTotal { get; set; }
        public decimal BillTotalWithoutCharges { get; set; }
        public decimal TotalCharges { get; set; }
        public List<PersonBillItemDto> PersonBillItems { get; set; }
    }
}
