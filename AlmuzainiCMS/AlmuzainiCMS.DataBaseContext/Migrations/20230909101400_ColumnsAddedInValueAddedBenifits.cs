using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ColumnsAddedInValueAddedBenifits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeftSectionFirstTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeftSectionSecondTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeftSectionThirdTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RightSectionFirstTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RightSectionFourthTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RightSectionSecondTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RightSectionThirdTitle",
                table: "ValueAddedBenifits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftSectionFirstTitle",
                table: "ValueAddedBenifits");

            migrationBuilder.DropColumn(
                name: "LeftSectionSecondTitle",
                table: "ValueAddedBenifits");

            migrationBuilder.DropColumn(
                name: "LeftSectionThirdTitle",
                table: "ValueAddedBenifits");

            migrationBuilder.DropColumn(
                name: "RightSectionFirstTitle",
                table: "ValueAddedBenifits");

            migrationBuilder.DropColumn(
                name: "RightSectionFourthTitle",
                table: "ValueAddedBenifits");

            migrationBuilder.DropColumn(
                name: "RightSectionSecondTitle",
                table: "ValueAddedBenifits");

            migrationBuilder.DropColumn(
                name: "RightSectionThirdTitle",
                table: "ValueAddedBenifits");
        }
    }
}
