using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data
{
    public class SplitThatBillContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillItemConfiguration());
            modelBuilder.ApplyConfiguration(new PersonBillItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
