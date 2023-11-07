using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_DAL.Migrations
{
    public partial class EditAreaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_CategoryLists_Category_Id",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "CategoryLists");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Goals",
                newName: "Area_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_Category_Id",
                table: "Goals",
                newName: "IX_Goals_Area_Id");

            migrationBuilder.CreateTable(
                name: "Areaes",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areaes", x => x.AreaId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Areaes_Area_Id",
                table: "Goals",
                column: "Area_Id",
                principalTable: "Areaes",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Areaes_Area_Id",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "Areaes");

            migrationBuilder.RenameColumn(
                name: "Area_Id",
                table: "Goals",
                newName: "Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_Area_Id",
                table: "Goals",
                newName: "IX_Goals_Category_Id");

            migrationBuilder.CreateTable(
                name: "CategoryLists",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLists", x => x.CategoryId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_CategoryLists_Category_Id",
                table: "Goals",
                column: "Category_Id",
                principalTable: "CategoryLists",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
