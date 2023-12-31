﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewBankAccount.Entity.MainDbContexts;

#nullable disable

namespace NewBankAccount.Entity.Migrations
{
    [DbContext(typeof(BankAccountDbContext))]
    [Migration("20231006095431_collectiontolist")]
    partial class collectiontolist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("NewBankAccount.Domain.Models.AccountUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateJoined")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("IBan_Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<double>("TelephoneNumber")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountHolderId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("BankBalance")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.BankTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AmtTransacted")
                        .HasColumnType("REAL");

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("TransDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TransactionType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("BankTransaction");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.InternationalMoneyTransfers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("TransAmount")
                        .HasColumnType("REAL");

                    b.Property<double?>("TransAmountAfterTaxExchangeRate")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("TransDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TransactionType")
                        .HasColumnType("TEXT");

                    b.Property<double?>("exchangeRate")
                        .HasColumnType("REAL");

                    b.Property<double?>("taxAmount")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("InternationalMoneyTransfers");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.BankAccount", b =>
                {
                    b.HasOne("NewBankAccount.Domain.Models.AccountUser", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");

                    b.Navigation("AccountHolder");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.BankTransaction", b =>
                {
                    b.HasOne("NewBankAccount.Domain.Models.BankAccount", "BankAccount")
                        .WithMany("BankTransactions")
                        .HasForeignKey("BankAccountId");

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.InternationalMoneyTransfers", b =>
                {
                    b.HasOne("NewBankAccount.Domain.Models.BankAccount", "BankAccount")
                        .WithMany("BankTransfers")
                        .HasForeignKey("BankAccountId");

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("NewBankAccount.Domain.Models.BankAccount", b =>
                {
                    b.Navigation("BankTransactions");

                    b.Navigation("BankTransfers");
                });
#pragma warning restore 612, 618
        }
    }
}
