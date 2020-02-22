using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    var splitThatBillContext = services.GetService<SplitThatBillContext>();
                    splitThatBillContext.Database.EnsureDeleted();
                    //splitThatBillContext.Database.EnsureCreated();
                    splitThatBillContext.Database.Migrate();

                    var dateTimeManager = services.GetRequiredService<IDateTimeManager>();
                    var externalIdGenerator = services.GetRequiredService<IExternalIdGenerator>();

                    var dataSeeder = new DataSeeder(splitThatBillContext, dateTimeManager, externalIdGenerator);
                    dataSeeder.Seed();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError("An error has occurred while migrating the database.", ex);
                }
            }


            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
