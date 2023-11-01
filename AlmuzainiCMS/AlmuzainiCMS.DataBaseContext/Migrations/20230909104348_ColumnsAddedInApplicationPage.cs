using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ColumnsAddedInApplicationPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoFiveThumbnailImagePath",
                table: "ApplicationPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoFourThumbnailImagePath",
                table: "ApplicationPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoOneThumbnailImagePath",
                table: "ApplicationPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoThreeThumbnailImagePath",
                table: "ApplicationPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoTwoThumbnailImagePath",
                table: "ApplicationPages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoFiveThumbnailImagePath",
                table: "ApplicationPages");

            migrationBuilder.DropColumn(
                name: "VideoFourThumbnailImagePath",
                table: "ApplicationPages");

            migrationBuilder.DropColumn(
                name: "VideoOneThumbnailImagePath",
                table: "ApplicationPages");

            migrationBuilder.DropColumn(
                name: "VideoThreeThumbnailImagePath",
                table: "ApplicationPages");

            migrationBuilder.DropColumn(
                name: "VideoTwoThumbnailImagePath",
                table: "ApplicationPages");
        }
    }
}
