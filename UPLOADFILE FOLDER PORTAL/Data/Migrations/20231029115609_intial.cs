using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPLOADFILE_FOLDER_PORTAL.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Main_Cat_Id = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Createdby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifiedby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_Main_Cat_Id",
                        column: x => x.Main_Cat_Id,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FolderName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FolderPath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Main_Folder_Id = table.Column<int>(type: "int", nullable: true),
                    Createdby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifiedby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folder_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folder_Folder_Main_Folder_Id",
                        column: x => x.Main_Folder_Id,
                        principalTable: "Folder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FolderId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Createdby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifiedby = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Main_Cat_Id",
                table: "Category",
                column: "Main_Cat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_CategoryId",
                table: "Folder",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_Main_Folder_Id",
                table: "Folder",
                column: "Main_Folder_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folder");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
