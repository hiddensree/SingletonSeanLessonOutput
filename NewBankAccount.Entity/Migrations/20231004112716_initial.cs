using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBankAccount.Entity.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IBan_Id = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    TelephoneNumber = table.Column<double>(type: "REAL", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountHolderId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankBalance = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Users_AccountHolderId",
                        column: x => x.AccountHolderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    AmtTransacted = table.Column<double>(type: "REAL", nullable: true),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: true),
                    TransDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransaction_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InternationalMoneyTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransAmount = table.Column<double>(type: "REAL", nullable: true),
                    taxAmount = table.Column<double>(type: "REAL", nullable: true),
                    exchangeRate = table.Column<double>(type: "REAL", nullable: true),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: true),
                    TransAmountAfterTaxExchangeRate = table.Column<double>(type: "REAL", nullable: true),
                    TransDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalMoneyTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternationalMoneyTransfers_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountHolderId",
                table: "BankAccount",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_BankAccountId",
                table: "BankTransaction",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalMoneyTransfers_BankAccountId",
                table: "InternationalMoneyTransfers",
                column: "BankAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "InternationalMoneyTransfers");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
