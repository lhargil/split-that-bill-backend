using System;
using System.Collections.Generic;
using System.Linq;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Core.OwnedEntities;

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
            var person1 = new Person("lhar", "gil");
            var person2 = new Person("jon", "snow");
            var person3 = new Person("raffy", "tulfo");

            if (!_splitThatBillContext.People.Any())
            {
                _splitThatBillContext.People.Add(person1);
                _splitThatBillContext.People.Add(person2);
                _splitThatBillContext.People.Add(person3);
            }

            if (!_splitThatBillContext.Bills.Any())
            {
                var billItem1 = new BillItem("Cup of rice", 3.0M);
                var billITem2 = new BillItem("Ayam goreng", 7.0M);
                var bill = new Bill("Sri Ayutthaya",
                    _dateTimeManager.Today,
                    new List<BillItem> {
                        billItem1,
                        billITem2
                    });
                bill.AddParticipant(person3);
                bill.AddParticipant(person2);

                var extraCharge1 = new ExtraCharge("Service charge", 0.10M);
                var extraCharge2 = new ExtraCharge("SST", 0.06M);
                bill.AddExtraCharge(extraCharge1);
                bill.AddExtraCharge(extraCharge2);

                person2.AddBillItem(billItem1, billItem1.UnitPrice);
                bill.UpdateBillTaker(person1);

                _splitThatBillContext.Bills.Add(bill);

                var billItem3 = new BillItem("Nasi lemak", 10.0M);
                var billItem4 = new BillItem("Avocado toast", 15.5M);
                var bill2 = new Bill("Feebay.co", _dateTimeManager.Today,
                    new List<BillItem> {
                        billItem3,
                        billItem4
                    });
                bill2.AddParticipant(person1);
                bill2.AddParticipant(person2);

                person1.AddBillItem(billItem4, billItem4.UnitPrice);
                var extraCharge3 = new ExtraCharge("Service charge", 0.10M);
                var extraCharge4 = new ExtraCharge("SST", 0.06M);
                bill2.AddExtraCharge(extraCharge3);
                bill2.AddExtraCharge(extraCharge4);

                bill2.UpdateBillTaker(person1);

                _splitThatBillContext.Bills.Add(bill2);

                _splitThatBillContext.SaveChanges();
            }
        }
    }
}
