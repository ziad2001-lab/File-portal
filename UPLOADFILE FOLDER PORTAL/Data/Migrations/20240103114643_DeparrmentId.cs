using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPLOADFILE_FOLDER_PORTAL.Data.Migrations
{
    public partial class DeparrmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_departments_DepartmentId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeparmentId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_departments_DepartmentId",
                table: "Category",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_departments_DepartmentId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeparmentId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_departments_DepartmentId",
                table: "Category",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }
    }
}
