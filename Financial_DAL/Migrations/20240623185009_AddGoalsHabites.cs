using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class AddGoalsHabites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DailyHabits",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyHabits",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeeklyHabits",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyHabits",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "MonthlyHabits",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "WeeklyHabits",
                table: "Goals");
        }
    }
}
