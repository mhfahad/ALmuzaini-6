using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ValuesItemTableAddedInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValuesItem_MissionVisionValues_MissionVisionValuesId",
                table: "ValuesItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValuesItem",
                table: "ValuesItem");

            migrationBuilder.RenameTable(
                name: "ValuesItem",
                newName: "ValuesItems");

            migrationBuilder.RenameIndex(
                name: "IX_ValuesItem_MissionVisionValuesId",
                table: "ValuesItems",
                newName: "IX_ValuesItems_MissionVisionValuesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValuesItems",
                table: "ValuesItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuesItems_MissionVisionValues_MissionVisionValuesId",
                table: "ValuesItems",
                column: "MissionVisionValuesId",
                principalTable: "MissionVisionValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValuesItems_MissionVisionValues_MissionVisionValuesId",
                table: "ValuesItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValuesItems",
                table: "ValuesItems");

            migrationBuilder.RenameTable(
                name: "ValuesItems",
                newName: "ValuesItem");

            migrationBuilder.RenameIndex(
                name: "IX_ValuesItems_MissionVisionValuesId",
                table: "ValuesItem",
                newName: "IX_ValuesItem_MissionVisionValuesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValuesItem",
                table: "ValuesItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuesItem_MissionVisionValues_MissionVisionValuesId",
                table: "ValuesItem",
                column: "MissionVisionValuesId",
                principalTable: "MissionVisionValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
