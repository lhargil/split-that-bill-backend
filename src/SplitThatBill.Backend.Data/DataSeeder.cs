using System;
using System.Collections.Generic;
using System.Linq;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;

namespace SplitThatBill.Backend.Data
{
    public class DataSeeder
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IDateTimeManager _dateTimeManager;

        public DataSeeder(SplitThatBillContext splitThatBillContext, IDateTimeManager dateTimeManager)
        {
            _splitThatBillContext = splitThatBillContext;
            _dateTimeManager = dateTimeManager;
        }

        public void Seed()
        {
            if (!_splitThatBillContext.Bills.Any())
            {
                var person1 = new Person("lhar", "gil");
                var person2 = new Person("jon", "snow");
                var billItem1 = new BillItem("Cup of rice", 3.0M);
                var billITem2 = new BillItem("Ayam goreng", 7.0M);
                var bill = new Bill("Sri Ayutthaya",
                    _dateTimeManager.Today,
                    null,
                    new List<BillItem> {
                        billItem1,
                        billITem2
                    });

                var extraCharge1 = new Core.OwnedEntities.ExtraCharge("Service charge", 0.10M);
                var extraCharge2 = new Core.OwnedEntities.ExtraCharge("SST", 0.06M);
                bill.AddExtraCharge(extraCharge1);
                bill.AddExtraCharge(extraCharge2);
                person2.AddBillItem(billItem1, billItem1.UnitPrice);
                _splitThatBillContext.People.Add(person1);
                _splitThatBillContext.People.Add(person2);
                _splitThatBillContext.Bills.Add(bill);
                _splitThatBillContext.SaveChanges();
            }
        }
    }
}
