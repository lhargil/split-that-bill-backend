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

            builder
                .HasMany(p => p.Bills)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);

            builder
                .HasMany(p => p.BillsTaken)
                .WithOne(p => p.BillTaker)
                .HasForeignKey(p => p.BillTakerId);

            builder.OwnsMany(p => p.PaymentDetails, a =>
            {
                a.HasForeignKey(p => p.PersonId);
                a.Property(p => p.Id);
                a.HasKey(p => new { p.PersonId, p.Id });
            });

            base.Configure(builder);
        }
    }
}
