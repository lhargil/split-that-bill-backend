using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class PersonConfiguration : BaseEntityTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder
                .HasMany(p => p.PersonBillItems)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);
            base.Configure(builder);
        }
    }
}
