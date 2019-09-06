﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitThatBill.Backend.Business.Dtos
{
    public class BillDto
    {
        public int Id { get; private set; }
        public string EstablishmentName { get; private set; }
        public string BillDate { get; private set; }
        public string Remarks { get; private set; }
        public List<BillItemDto> BillItems { get; private set; }
    }
}
