using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBankAccount.Entity.Migrations
{
    /// <inheritdoc />
    public partial class modifyinternationalmoneytransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransAmountAfterTaxExchangeRate",
                table: "InternationalMoneyTransfers");

            migrationBuilder.AddColumn<string>(
                name: "TargetCountry",
                table: "InternationalMoneyTransfers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetCountry",
                table: "InternationalMoneyTransfers");

            migrationBuilder.AddColumn<double>(
                name: "TransAmountAfterTaxExchangeRate",
                table: "InternationalMoneyTransfers",
                type: "REAL",
                nullable: true);
        }
    }
}
