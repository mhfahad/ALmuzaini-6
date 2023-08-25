using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class MissionVisionValuesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissionVisionValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MissionVisionBannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesItem10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionVisionValues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionVisionValues");
        }
    }
}
