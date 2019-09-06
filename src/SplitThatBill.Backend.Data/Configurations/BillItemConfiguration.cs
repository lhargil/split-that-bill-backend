using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class BillItemConfiguration : BaseEntityTypeConfiguration<BillItem>
    {
        public override void Configure(EntityTypeBuilder<BillItem> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.Bill)
                .WithMany(p => p.BillItems)
                .HasForeignKey(p => p.BillId)
                .IsRequired();

            builder
                .HasMany(p => p.PersonBillItems)
                .WithOne(p => p.BillItem)
                .HasForeignKey(p => p.BillItemId);

            base.Configure(builder);
        }
    }
}
