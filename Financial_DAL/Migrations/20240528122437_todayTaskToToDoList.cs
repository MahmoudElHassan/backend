using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class todayTaskToToDoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "TodayTask",
            //    table: "Transactions");

            migrationBuilder.AddColumn<bool>(
                name: "TodayTask",
                table: "ToDoLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodayTask",
                table: "ToDoLists");

            //migrationBuilder.AddColumn<bool>(
            //    name: "TodayTask",
            //    table: "Transactions",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);
        }
    }
}
