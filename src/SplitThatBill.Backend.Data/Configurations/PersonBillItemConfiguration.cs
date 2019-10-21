using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class PersonBillItemConfiguration : BaseEntityTypeConfiguration<PersonBillItem>
    {
        public override void Configure(EntityTypeBuilder<PersonBillItem> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.BillItem)
                .WithMany(p => p.PersonBillItems)
                .HasForeignKey(p => p.BillItemId);

            builder
                .HasOne(p => p.Person)
                .WithMany(p => p.PersonBillItems)
                .HasForeignKey(p => p.PersonId);

            builder
                .HasQueryFilter(b => !EF.Property<bool>(b, "IsDeleted"));

            base.Configure(builder);
        }
    }
}
