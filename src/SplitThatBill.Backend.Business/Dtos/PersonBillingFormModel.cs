using System;
using System.Collections.Generic;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class PersonBillingFormModel
    {
        public PersonBillingFormModel()
        {
            BillItems = new List<BillItemFormModel>();
        }
        public PersonFormModel Person { get; set; }
        public BillFormModel Bill { get; set; }
        public List<BillItemFormModel> BillItems { get; set; }
    }
}
