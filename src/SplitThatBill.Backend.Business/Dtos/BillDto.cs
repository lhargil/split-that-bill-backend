using System;
using System.Collections.Generic;
using System.Linq;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.ValueObjects;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillDto
    {
        public int Id { get; private set; }
        public string EstablishmentName { get; private set; }
        public string BillDate { get; private set; }
        public string Remarks { get; private set; }
    }

    public class BillItemDto
    {
        private readonly BillItem _billItem;

        public BillItemDto(BillItem billItem)
        {
            _billItem = billItem;
        }

        public string Description => _billItem.Description;
        public Money UnitPrice => new Money(_billItem.UnitPrice);
    }
}
