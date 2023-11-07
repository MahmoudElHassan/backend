using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class addPaymentTableToTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Transactions");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transaction_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Transactions_Transaction_Id",
                        column: x => x.Transaction_Id,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Transaction_Id",
                table: "Payments",
                column: "Transaction_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
