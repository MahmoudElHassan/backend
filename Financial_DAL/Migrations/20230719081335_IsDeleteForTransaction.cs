using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class IsDeleteForTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Transactions");
        }
    }
}
