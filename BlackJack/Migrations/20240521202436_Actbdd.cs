using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackJack.Migrations
{
    /// <inheritdoc />
    public partial class Actbdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_CreditCard_CreditCardId",
                table: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethod_CreditCardId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "PaymentMethod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "PaymentMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CreditCardId",
                table: "PaymentMethod",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_CreditCard_CreditCardId",
                table: "PaymentMethod",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
