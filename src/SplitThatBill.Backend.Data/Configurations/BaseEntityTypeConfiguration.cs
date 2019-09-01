using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitThatBill.Backend.Data.Configurations
{
    // Using IEntityTypeConfiguration<T> to configure an entity
    // This base class is configured so that each entity in the context will have a uniform set of audit fields
    // see: https://stackoverflow.com/questions/52020107/how-to-add-the-same-column-to-all-entities-in-ef-core
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T: class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<DateTime>("DateCreated")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            builder.Property<DateTime>("DateModified")
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            builder.Property<Boolean>("IsDeleted")
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property<byte[]>("Version")
                .ValueGeneratedOnAdd()
                .IsRowVersion();
            builder.Property<string>("ModifiedBy");
            builder.Property<string>("CreatedBy");
        }
    }
}
