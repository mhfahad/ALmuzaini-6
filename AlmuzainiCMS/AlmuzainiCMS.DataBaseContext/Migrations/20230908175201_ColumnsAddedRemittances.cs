using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ColumnsAddedRemittances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RemitNowImageOneText",
                table: "Remittences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemitNowImageTwoText",
                table: "Remittences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemitNowImageOneText",
                table: "Remittences");

            migrationBuilder.DropColumn(
                name: "RemitNowImageTwoText",
                table: "Remittences");
        }
    }
}
