using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class AddHomeCompanyDetailsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeCompanyDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxOneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxOneDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxTwoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxTwoDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxThreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxThreeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxFourTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxFourDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCompanyDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeCompanyDetails");
        }
    }
}
