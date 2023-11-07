using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class EditCalenderHabit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calenders_Habits_Habit_Id",
                table: "Calenders");

            migrationBuilder.DropIndex(
                name: "IX_Calenders_Habit_Id",
                table: "Calenders");

            migrationBuilder.DropColumn(
                name: "Habit_Id",
                table: "Calenders");

            migrationBuilder.AddColumn<int>(
                name: "Calender_Id",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Habits_Calender_Id",
                table: "Habits",
                column: "Calender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Calenders_Calender_Id",
                table: "Habits",
                column: "Calender_Id",
                principalTable: "Calenders",
                principalColumn: "CalenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Calenders_Calender_Id",
                table: "Habits");

            migrationBuilder.DropIndex(
                name: "IX_Habits_Calender_Id",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Calender_Id",
                table: "Habits");

            migrationBuilder.AddColumn<int>(
                name: "Habit_Id",
                table: "Calenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_Habit_Id",
                table: "Calenders",
                column: "Habit_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calenders_Habits_Habit_Id",
                table: "Calenders",
                column: "Habit_Id",
                principalTable: "Habits",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
