using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitThatBill.Backend.Data.Migrations
{
    public partial class UpdateExtraCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtraCharge",
                table: "ExtraCharge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "PersonBillItem",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "People",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExtraCharge",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "Bills",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "BillItem",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtraCharge",
                table: "ExtraCharge",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCharge_BillId",
                table: "ExtraCharge",
                column: "BillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtraCharge",
                table: "ExtraCharge");

            migrationBuilder.DropIndex(
                name: "IX_ExtraCharge_BillId",
                table: "ExtraCharge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "PersonBillItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "People",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExtraCharge",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "Bills",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Version",
                table: "BillItem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtraCharge",
                table: "ExtraCharge",
                columns: new[] { "BillId", "Id" });
        }
    }
}
