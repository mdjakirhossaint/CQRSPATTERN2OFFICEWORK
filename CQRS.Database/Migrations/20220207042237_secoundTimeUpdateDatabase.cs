using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRS.Database.Migrations
{
    public partial class secoundTimeUpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TblBrandID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TblCategoryID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TblBrandID",
                table: "Products",
                column: "TblBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TblCategoryID",
                table: "Products",
                column: "TblCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_TblBrandID",
                table: "Products",
                column: "TblBrandID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_TblCategoryID",
                table: "Products",
                column: "TblCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_TblBrandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_TblCategoryID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_TblBrandID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TblCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TblBrandID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TblCategoryID",
                table: "Products");
        }
    }
}
