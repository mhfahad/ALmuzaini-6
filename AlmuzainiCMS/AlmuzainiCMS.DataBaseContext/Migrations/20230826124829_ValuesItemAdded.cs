using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ValuesItemAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValuesItem1",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem10",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem2",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem3",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem4",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem5",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem6",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem7",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem8",
                table: "MissionVisionValues");

            migrationBuilder.DropColumn(
                name: "ValuesItem9",
                table: "MissionVisionValues");

            migrationBuilder.CreateTable(
                name: "ValuesItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValuesItemText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionVisionValuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuesItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuesItem_MissionVisionValues_MissionVisionValuesId",
                        column: x => x.MissionVisionValuesId,
                        principalTable: "MissionVisionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValuesItem_MissionVisionValuesId",
                table: "ValuesItem",
                column: "MissionVisionValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValuesItem");

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem1",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem10",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem2",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem3",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem4",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem5",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem6",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem7",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem8",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValuesItem9",
                table: "MissionVisionValues",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
