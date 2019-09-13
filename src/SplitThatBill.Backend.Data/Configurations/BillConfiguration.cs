using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class BillConfiguration : BaseEntityTypeConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder
                .HasMany(p => p.BillItems)
                .WithOne(p => p.Bill)
                .IsRequired();

            builder
                .HasOne(p => p.BillTaker)
                .WithOne(p => p.Bill)
                .HasForeignKey<Person>(p => p.BillId)
                .IsRequired();

            // Owned entities
            builder.OwnsMany(p => p.ExtraCharges, a =>
            {
                a.HasForeignKey("BillId");
                a.Property(p => p.Id).ValueGeneratedOnAdd();
                a.HasKey(p => p.Id);
            });

            base.Configure(builder);
        }
    }
}
