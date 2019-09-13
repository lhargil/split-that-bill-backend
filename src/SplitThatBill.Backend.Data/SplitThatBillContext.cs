using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SplitThatBill.Backend.Data
{
    public class SplitThatBillContext : DbContext
    {
        private readonly IContextData _contextData;
        private readonly IDateTimeManager _dateTimeManager;

        public SplitThatBillContext(DbContextOptions<SplitThatBillContext> options
            , IContextData contextData
            , IDateTimeManager dateTimeManager)
            : base(options)
        {
            _contextData = contextData;
            _dateTimeManager = dateTimeManager;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillItemConfiguration());
            modelBuilder.ApplyConfiguration(new PersonBillItemConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Person> People { get; set; }

        public override int SaveChanges()
        {
            var saveTask = Task.Run(async () =>
            {
                return await this.SaveChangesAsync();
            });
            return saveTask.Result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                e.State == EntityState.Modified ||
                e.State == EntityState.Deleted))
            {
                var today = _dateTimeManager.Today;
                var currentUser = _contextData.CurrentUser;

                if (entry.Metadata.FindProperty("DateModified") == null)
                {
                    continue;
                }
                entry.Property("DateModified").CurrentValue = today;
                entry.Property("ModifiedBy").CurrentValue = currentUser;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreated").CurrentValue = today;
                    entry.Property("CreatedBy").CurrentValue = currentUser;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("IsDeleted").CurrentValue = true;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
