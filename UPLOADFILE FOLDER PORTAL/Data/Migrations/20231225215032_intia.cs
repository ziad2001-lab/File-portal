using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPLOADFILE_FOLDER_PORTAL.Data.Migrations
{
    public partial class intia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileExtensionMappingId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileExtensionMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtensionMappings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileExtensionMappingId",
                table: "Files",
                column: "FileExtensionMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileExtensionMappings_FileExtensionMappingId",
                table: "Files",
                column: "FileExtensionMappingId",
                principalTable: "FileExtensionMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileExtensionMappings_FileExtensionMappingId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "FileExtensionMappings");

            migrationBuilder.DropIndex(
                name: "IX_Files_FileExtensionMappingId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileExtensionMappingId",
                table: "Files");
        }
    }
}
