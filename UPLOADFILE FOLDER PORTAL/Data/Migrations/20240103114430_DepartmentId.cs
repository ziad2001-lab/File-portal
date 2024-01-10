using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPLOADFILE_FOLDER_PORTAL.Data.Migrations
{
    public partial class DepartmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_departments_DeparmentIt",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_departments_DeparmentIt",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_DeparmentIt",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "DeparmentIt",
                table: "Category",
                newName: "DeparmentId");

            migrationBuilder.RenameColumn(
                name: "DeparmentIt",
                table: "AspNetUsers",
                newName: "DeparmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DeparmentIt",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DeparmentId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_DepartmentId",
                table: "Category",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_departments_DeparmentId",
                table: "AspNetUsers",
                column: "DeparmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_departments_DepartmentId",
                table: "Category",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_departments_DeparmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_departments_DepartmentId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_DepartmentId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "DeparmentId",
                table: "Category",
                newName: "DeparmentIt");

            migrationBuilder.RenameColumn(
                name: "DeparmentId",
                table: "AspNetUsers",
                newName: "DeparmentIt");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DeparmentId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DeparmentIt");

            migrationBuilder.CreateIndex(
                name: "IX_Category_DeparmentIt",
                table: "Category",
                column: "DeparmentIt");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_departments_DeparmentIt",
                table: "AspNetUsers",
                column: "DeparmentIt",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_departments_DeparmentIt",
                table: "Category",
                column: "DeparmentIt",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
