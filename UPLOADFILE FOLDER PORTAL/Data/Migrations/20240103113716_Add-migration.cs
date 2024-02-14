using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPLOADFILE_FOLDER_PORTAL.Data.Migrations
{
    public partial class Addmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileExtensionMappings_FileExtensionMappingId",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Files",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "FileExtensionMappingId",
                table: "Files",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeparmentIt",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeparmentIt",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmenName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Createdby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifiedby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_DeparmentIt",
                table: "Category",
                column: "DeparmentIt");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeparmentIt",
                table: "AspNetUsers",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileExtensionMappings_FileExtensionMappingId",
                table: "Files",
                column: "FileExtensionMappingId",
                principalTable: "FileExtensionMappings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_departments_DeparmentIt",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_departments_DeparmentIt",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileExtensionMappings_FileExtensionMappingId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropIndex(
                name: "IX_Category_DeparmentIt",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DeparmentIt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeparmentIt",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeparmentIt",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Files",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileExtensionMappingId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileExtensionMappings_FileExtensionMappingId",
                table: "Files",
                column: "FileExtensionMappingId",
                principalTable: "FileExtensionMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
