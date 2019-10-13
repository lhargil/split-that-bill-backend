using System;
using System.Collections.Generic;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillFormModel
    {
        private BillFormModel()
        {
            BillItems = new List<BillItemFormModel>();
            ExtraCharges = new List<ExtraChargeFormModel>();
        }
        public BillFormModel(int id, string establishmentName, DateTime billDate, string remarks) : this()
        {
            Id = id;
            EstablishmentName = establishmentName;
            BillDate = billDate;
            Remarks = remarks;
        }
        public int Id { get; set; }
        public string EstablishmentName { get; set; }
        public DateTime BillDate { get; set; }
        public string Remarks { get; set; }
        public List<BillItemFormModel> BillItems { get; set; }
        public List<ExtraChargeFormModel> ExtraCharges { get; set; }
    }
}
