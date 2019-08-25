using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class BillItemConfiguration: BaseEntityTypeConfiguration<BillItem>
    {
        public override void Configure(EntityTypeBuilder<BillItem> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            base.Configure(builder);
        }
    }
}
