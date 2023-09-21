using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ColumnAddedINForeignCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuySellCurrencyLinkOneText",
                table: "ForeignCurrency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuySellCurrencyLinkTwo",
                table: "ForeignCurrency",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuySellCurrencyLinkOneText",
                table: "ForeignCurrency");

            migrationBuilder.DropColumn(
                name: "BuySellCurrencyLinkTwo",
                table: "ForeignCurrency");
        }
    }
}
