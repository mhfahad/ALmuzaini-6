using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class CompanyHistoryAddedv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpertiseImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpertiseText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkforceImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkforceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologyImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologyText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyHistoryImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyHistory");
        }
    }
}
