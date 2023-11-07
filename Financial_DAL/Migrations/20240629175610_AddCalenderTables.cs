using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class AddCalenderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Areaes_Area_Id",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Areaes",
                table: "Areaes");

            migrationBuilder.RenameTable(
                name: "Areaes",
                newName: "Areas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Areas",
                table: "Areas",
                column: "AreaId");

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    HabitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.HabitId);
                });

            migrationBuilder.CreateTable(
                name: "Calenders",
                columns: table => new
                {
                    CalenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Habit_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calenders", x => x.CalenderId);
                    table.ForeignKey(
                        name: "FK_Calenders_Habits_Habit_Id",
                        column: x => x.Habit_Id,
                        principalTable: "Habits",
                        principalColumn: "HabitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_Habit_Id",
                table: "Calenders",
                column: "Habit_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Areas_Area_Id",
                table: "Goals",
                column: "Area_Id",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Areas_Area_Id",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "Calenders");

            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Areas",
                table: "Areas");

            migrationBuilder.RenameTable(
                name: "Areas",
                newName: "Areaes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Areaes",
                table: "Areaes",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Areaes_Area_Id",
                table: "Goals",
                column: "Area_Id",
                principalTable: "Areaes",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
