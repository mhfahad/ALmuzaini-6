﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class AddCorporateSocialRespBannerToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateSocialRespBanners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateSocialRespBannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateSocialRespBanners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateSocialRespBanners");
        }
    }
}
