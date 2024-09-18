using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCQRU.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pro_reg",
                columns: table => new
                {
                    Pro_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatchSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comp_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dispatch_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doc_Flag = table.Column<int>(type: "int", nullable: false),
                    Doc_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pro_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pro_Doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pro_Entry_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pro_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Row_ID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sound_Flag = table.Column<int>(type: "int", nullable: false),
                    Sound_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_Flag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Update_Flag_E = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Update_Flag_H = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_reg", x => x.Pro_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pro_reg");
        }
    }
}
