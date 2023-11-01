using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "PromotionNews");

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubOneSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubOneSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubOneSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubTwoSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubTwoSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubTwoSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubThreeSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubThreeSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubThreeSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubFourSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubFourSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubFourSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubFiveSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubFiveSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSubFiveSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubOneSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubOneSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubOneSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubTwoSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubTwoSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubTwoSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubThreeSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubThreeSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubThreeSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubFourSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubFourSectionIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSubFourSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionOneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionOneImageath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionOneText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionTwoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionTwoImageath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionTwoText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionThreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionThreeImageath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionThreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionFourTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionFourImageath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionFourText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionFiveTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionFiveImageath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsSectionFiveText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "PromotionNews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
