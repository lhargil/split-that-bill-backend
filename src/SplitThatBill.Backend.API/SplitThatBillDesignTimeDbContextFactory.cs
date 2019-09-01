using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.API
{
    public class SplitThatBillDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SplitThatBillContext>
    {
        private const string _databaseName = "SplitThatBillDb";
        private const string _migrationAssembly = "SplitThatBill.Backend.Data";

        public SplitThatBillContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var configuration = configurationBuilder
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(_databaseName);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SplitThatBillContext>()
                .UseMySql(connectionString, x => x.MigrationsAssembly(_migrationAssembly));

            return new SplitThatBillContext(dbContextOptionsBuilder.Options);
        }
    }
}
