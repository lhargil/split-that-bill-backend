using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.API
{
    public class SplitThatBillDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SplitThatBillContext>
    {
        public SplitThatBillContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configurationBuilder = new ConfigurationBuilder();

            if (environmentName.ToLower() == "development")
            {
                configurationBuilder.AddUserSecrets<Startup>();
            }

            configurationBuilder.AddEnvironmentVariables();
            var configuration = configurationBuilder.Build();

            var connectionString = configuration.GetConnectionString("SplitThatBillDb");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SplitThatBillContext>()
                .UseMySql(connectionString);

            return new SplitThatBillContext(dbContextOptionsBuilder.Options);
        }
    }
}

/*
public AppContext CreateDbContext(string[] args)
   {
       // IDesignTimeDbContextFactory is used usually when you execute EF Core commands like Add-Migration, Update-Database, and so on
       // So it is usually your local development machine environment
       var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

       // Prepare configuration builder
       var configuration = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
           .AddJsonFile("appsettings.json", optional: false)
           .AddJsonFile($"appsettings.{envName}.json", optional: false)
           .Build();

       // Bind your custom settings class instance to values from appsettings.json
       var settingsSection = configuration.GetSection("Settings");
       var appSettings = new AppSettings();
       settingsSection.Bind(appSettings);

       // Create DB context with connection from your AppSettings 
       var optionsBuilder = new DbContextOptionsBuilder<AppContext>()
           .UseMySql(appSettings.DefaultConnection);

       return new AppContext(optionsBuilder.Options);
   }
     */
