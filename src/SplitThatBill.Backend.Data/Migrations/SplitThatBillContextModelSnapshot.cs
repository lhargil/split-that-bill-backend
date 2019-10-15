﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Data.Migrations
{
    [DbContext(typeof(SplitThatBillContext))]
    partial class SplitThatBillContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

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

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<decimal?>("DiscountRate");

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

                    b.Property<int?>("BillId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Firstname");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Lastname");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BillId")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.PersonBillItem", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("BillItemId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

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

            modelBuilder.Entity("SplitThatBill.Backend.Core.Entities.Bill", b =>
                {
                    b.OwnsMany("SplitThatBill.Backend.Core.OwnedEntities.ExtraCharge", "ExtraCharges", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<int>("BillId");

                            b1.Property<string>("Description");

                            b1.Property<decimal>("Rate");

                            b1.HasKey("Id");

                            b1.HasIndex("BillId");

                            b1.ToTable("ExtraCharge");

                            b1.HasOne("SplitThatBill.Backend.Core.Entities.Bill")
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
                        .HasForeignKey("SplitThatBill.Backend.Core.Entities.Person", "BillId");

                    b.OwnsMany("SplitThatBill.Backend.Core.OwnedEntities.PaymentDetail", "PaymentDetails", b1 =>
                        {
                            b1.Property<int>("PersonId");

                            b1.Property<int>("Id");

                            b1.Property<string>("AccountName");

                            b1.Property<string>("AccountNumber");

                            b1.Property<string>("BankName");

                            b1.HasKey("PersonId", "Id");

                            b1.ToTable("PaymentDetail");

                            b1.HasOne("SplitThatBill.Backend.Core.Entities.Person", "Person")
                                .WithMany("PaymentDetails")
                                .HasForeignKey("PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
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
#pragma warning restore 612, 618
        }
    }
}
