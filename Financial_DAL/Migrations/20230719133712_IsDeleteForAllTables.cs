using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class IsDeleteForAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "UserDatabases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ToDoLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "UserDatabases");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Categories");
        }
    }
}
