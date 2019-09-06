using System;
using System.Collections.Generic;
using System.Linq;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.ValueObjects;

namespace SplitThatBill.Backend.API.Dtos
{
    public class BillDto
    {
        private readonly Bill _bill;

        public BillDto(Bill bill)
        {
            _bill = bill;
        }

        public int Id => _bill.Id;
        public string EstablishmentName => _bill.EstablishmentName;
        public string BillDate => _bill.BillDate.ToString("MMM dd yyyy");
        public List<BillItemDto> BillItems => _bill.BillItems.Select(item => new BillItemDto(item))
            .ToList();
        public List<PaymentDetailDto> PaymentDetails => _bill.PaymentDetails.Select(item => new PaymentDetailDto(item))
            .ToList();
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

    public class PaymentDetailDto
    {
        private readonly PaymentDetail _paymentDetail;

        public PaymentDetailDto(PaymentDetail paymentDetail)
        {
            _paymentDetail = paymentDetail;
        }
        public string BankName => _paymentDetail.BankName;
        public string AccountNumber => _paymentDetail.AccountNumber;
        public string AccountName => _paymentDetail.AccountName;
    }
}
