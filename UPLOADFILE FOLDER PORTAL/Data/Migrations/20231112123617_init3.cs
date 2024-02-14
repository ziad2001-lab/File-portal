using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPLOADFILE_FOLDER_PORTAL.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Category_RoleId",
                table: "Category",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetRoles_RoleId",
                table: "Category",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetRoles_RoleId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_RoleId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Category");
        }
    }
}
