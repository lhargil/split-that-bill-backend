﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Data.Migrations
{
    [DbContext(typeof(SplitThatBillContext))]
    [Migration("20190905023655_Initial-Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BillDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("EstablishmentName");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Remarks");

                    b.Property<DateTime?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.BillItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy");

                    b.Property<decimal>("UnitPrice");

                    b.Property<DateTime?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("BillItem");
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillId");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");

                    b.HasIndex("BillId")
                        .IsUnique();

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.PersonBillItem", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("BillItemId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy");

                    b.Property<decimal>("PayableUnitPrice");

                    b.Property<DateTime?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("PersonId", "BillItemId");

                    b.HasIndex("BillItemId");

                    b.ToTable("PersonBillItem");
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.OwnedEntities.PaymentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountNumber");

                    b.Property<string>("BankName");

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PaymentDetail");
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.Bill", b =>
                {
                    b.OwnsMany("SplitThatBill.Backend.Core.OwnedEntities.ExtraCharge", "ExtraCharges", b1 =>
                        {
                            b1.Property<int>("BillId");

                            b1.Property<int>("Id");

                            b1.Property<string>("Description");

                            b1.Property<decimal>("Rate");

                            b1.HasKey("BillId", "Id");

                            b1.ToTable("ExtraCharge");

                            b1.HasOne("SplitThatBill.Backend.Core.Entities.Bill", "Bill")
                                .WithMany("ExtraCharges")
                                .HasForeignKey("BillId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.BillItem", b =>
                {
                    b.HasOne("SplitThatBill.Backend.Core.Entities.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.Person", b =>
                {
                    b.HasOne("SplitThatBill.Backend.Core.Entities.Bill", "Bill")
                        .WithOne("BillTaker")
                        .HasForeignKey("SplitThatBill.Backend.Core.Entities.Person", "BillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.PersonBillItem", b =>
                {
                    b.HasOne("SplitThatBill.Backend.Core.Entities.BillItem", "BillItem")
                        .WithMany("PersonBillItems")
                        .HasForeignKey("BillItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SplitThatBill.Backend.Core.Entities.Person", "Person")
                        .WithMany("PersonBillItems")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.OwnedEntities.PaymentDetail", b =>
                {
                    b.HasOne("SplitThatBill.Backend.Core.Entities.Person", "Person")
                        .WithMany("PaymentDetails")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
