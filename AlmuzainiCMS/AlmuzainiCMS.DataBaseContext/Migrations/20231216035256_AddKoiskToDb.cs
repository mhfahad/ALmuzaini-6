using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class AddKoiskToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KoiskBanners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KoiskTopBannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoiskBanners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KoiskDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionHeaderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixthSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoiskDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KoiskBanners");

            migrationBuilder.DropTable(
                name: "KoiskDetails");
        }
    }
}
