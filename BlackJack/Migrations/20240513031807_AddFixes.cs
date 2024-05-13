using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackJack.Migrations
{
    /// <inheritdoc />
    public partial class AddFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "SupportTicket");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SupportTicket",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "SupportTicket",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResolutionDate",
                table: "SupportTicket",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "PaymentMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CreditCardId",
                table: "PaymentMethod",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_UserId",
                table: "CreditCard",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_CreditCard_CreditCardId",
                table: "PaymentMethod",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_CreditCard_CreditCardId",
                table: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethod_CreditCardId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "SupportTicket",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "SupportTicket",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResolutionDate",
                table: "SupportTicket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "SupportTicket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "PaymentMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
