using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VCQRU.Migrations
{
    public partial class AddCompositeKeyToUniqueCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniqueCodes",
                columns: table => new
                {
                    SeriesNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GeneratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueCodes", x => x.SeriesNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniqueCodes_Code1_Code2",
                table: "UniqueCodes",
                columns: new[] { "Code1", "Code2" },
                unique: true,
                filter: "[Code1] IS NOT NULL AND [Code2] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniqueCodes");
        }
    }
}
