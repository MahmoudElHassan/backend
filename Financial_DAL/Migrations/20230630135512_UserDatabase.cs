using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class UserDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ToDoLists",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    MCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MCategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.MCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MCategory_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategories_MainCategories_MCategory_Id",
                        column: x => x.MCategory_Id,
                        principalTable: "MainCategories",
                        principalColumn: "MCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDatabases",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BoyBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoyBirthPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GirlName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GirlBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GirlBirthPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SCategory_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatabases", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserDatabases_SubCategories_SCategory_Id",
                        column: x => x.SCategory_Id,
                        principalTable: "SubCategories",
                        principalColumn: "SCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_MCategory_Id",
                table: "SubCategories",
                column: "MCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDatabases_SCategory_Id",
                table: "UserDatabases",
                column: "SCategory_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDatabases");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "MainCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ToDoLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
