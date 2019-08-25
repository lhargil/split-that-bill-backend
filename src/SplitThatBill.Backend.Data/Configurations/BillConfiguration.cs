using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class BillConfiguration: BaseEntityTypeConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder
                .HasMany(p => p.BillItems)
                .WithOne(p => p.Bill)
                .IsRequired();

            builder
                .HasMany(p => p.PaymentDetails)
                .WithOne(p => p.Bill);

            // Owned entities
            builder.OwnsMany(p => p.ExtraCharges, a =>
            {
                a.HasForeignKey("BillId");
                a.Property<int>("Id");
                a.HasKey("BillId", "Id");
            });

            base.Configure(builder);
        }
    }
}
