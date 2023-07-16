using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class UserDatabaseAndMainCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MCategory_Id",
                table: "UserDatabases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDatabases_MCategory_Id",
                table: "UserDatabases",
                column: "MCategory_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDatabases_MainCategories_MCategory_Id",
                table: "UserDatabases",
                column: "MCategory_Id",
                principalTable: "MainCategories",
                principalColumn: "MCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDatabases_MainCategories_MCategory_Id",
                table: "UserDatabases");

            migrationBuilder.DropIndex(
                name: "IX_UserDatabases_MCategory_Id",
                table: "UserDatabases");

            migrationBuilder.DropColumn(
                name: "MCategory_Id",
                table: "UserDatabases");
        }
    }
}
