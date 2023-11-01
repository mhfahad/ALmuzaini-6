using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ColumnsAddedInRemittancesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoOneThumbnailImagePath",
                table: "Remittences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoTwoThumbnailImagePath",
                table: "Remittences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoOneThumbnailImagePath",
                table: "Remittences");

            migrationBuilder.DropColumn(
                name: "VideoTwoThumbnailImagePath",
                table: "Remittences");
        }
    }
}
