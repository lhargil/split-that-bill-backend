using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitThatBill.Backend.Data.Migrations
{
    public partial class AddCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var file = Path.Combine(AppContext.BaseDirectory, "Scripts/StoredProcedures/1.Add_Currencies.sql");
            migrationBuilder.Sql(File.ReadAllText(file));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop Table Currencies");
            migrationBuilder.Sql("Drop Procedure Add_Currencies");
        }
    }
}
