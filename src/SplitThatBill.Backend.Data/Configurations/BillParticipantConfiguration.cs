using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitThatBill.Backend.Core.Entities;

namespace SplitThatBill.Backend.Data.Configurations
{
    public class BillParticipantConfiguration : BaseEntityTypeConfiguration<BillParticipant>
    {
        public override void Configure(EntityTypeBuilder<BillParticipant> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.Bill)
                .WithMany(p => p.Participants)
                .HasForeignKey(p => p.BillId);

            builder
                .HasOne(p => p.Person)
                .WithMany(p => p.Bills)
                .HasForeignKey(p => p.PersonId);

            builder
                .HasQueryFilter(f => !EF.Property<bool>(f, "IsDeleted"));

            base.Configure(builder);
        }
    }
}
