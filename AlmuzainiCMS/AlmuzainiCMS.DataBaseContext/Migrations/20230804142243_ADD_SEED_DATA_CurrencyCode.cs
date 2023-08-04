using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ADD_SEED_DATA_CurrencyCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"   
            INSERT INTO CurrenyCodes VALUES (NEWID(),'INR')
            INSERT INTO CurrenyCodes VALUES (NEWID(),'BDT')
            INSERT INTO CurrenyCodes VALUES (NEWID(),'SAR')
            INSERT INTO CurrenyCodes VALUES (NEWID(),'EGP')
            INSERT INTO CurrenyCodes VALUES (NEWID(),'USD')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"TRUNCATE TABLE CurrenyCodes");
        }
    }
}
