using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ChairmanMessageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChairmanMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChairmanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChairmanImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeventhSection = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairmanMessage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChairmanMessage");
        }
    }
}
