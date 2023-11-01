using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    public partial class ModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABoutBoxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserGuideTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplePlayStoreIconImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePlayStoreIconImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppGalleryIconImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderOneImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTwoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderThreeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderFourImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconOneImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconOneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconTwoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconTwoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconThreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconThreeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconFourTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconFourImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconFiveTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconFiveImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconSixTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationIconSixImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionOneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionOneImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionOneDescriptionSectionOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionOneDescriptionSectionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionTwoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionTwoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionTwoDescriptionSectionOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionTwoDescriptionSectionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionThreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionThreeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionThreeDescriptionSectionOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionThreeDescriptionSectionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionFourthTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionFourthImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionFourthDescriptionSectionOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppFeaturesSectionFourthDescriptionSectionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppTutorialsSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoOneLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoOneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTwoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTwoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoThreeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoThreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoFourLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoFourTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoFiveLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoFiveTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corporate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderOneImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTwoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderThreeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderFourImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateClientsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactsText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForeignCurrency",
                columns: table => new
                {
                    CashCurrencyBannerImagePath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InnerSectionPageHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionPageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCDeliveryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCDeliveryImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCExchangeTextFirstSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCExchangeTextSecondSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCExchangeTextThirdSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuySellCurrencyText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuySellCurrencyLinkOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuySellCurrencyLinkTwoText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCodeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuySellCurrencyORText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ORDescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlideImageFileOnePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlideImageFileTwoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlideImageFileThreePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlideImageFileFourPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignCurrency", x => x.CashCurrencyBannerImagePath);
                });

            migrationBuilder.CreateTable(
                name: "NewsSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remittences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderOneImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTwoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderThreeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderFourImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionLeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionLeftText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionLeftImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionRightTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionRightText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSectionRightImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSectionImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSectionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSectionImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSectionLeftText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSectionLeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSectionRightText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSectionRightTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemitNowText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemitNowImageOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemitNowImageTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoOneLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoOneText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTwoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTwoText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remittences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValueAddedBenifits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerSectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionFirstText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionFirstImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionSecondText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionSecondImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionThirdText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftSectionThirdImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionFirstText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionFirstImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionSecondText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionSecondImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionThirdText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionThirdImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionFourthText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightSectionFourthImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueAddedBenifits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGuides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    UserGuideText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGuides_ApplicationPages_ApplicationPageId",
                        column: x => x.ApplicationPageId,
                        principalTable: "ApplicationPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    RequiredDocumentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredDocuments_Corporate_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "Corporate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsSectionNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewsSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSectionNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsSectionNews_NewsSections_NewsSectionId",
                        column: x => x.NewsSectionId,
                        principalTable: "NewsSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromotionNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionNews_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsSectionNews_NewsSectionId",
                table: "NewsSectionNews",
                column: "NewsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionNews_PromotionId",
                table: "PromotionNews",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredDocuments_CorporateId",
                table: "RequiredDocuments",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuides_ApplicationPageId",
                table: "UserGuides",
                column: "ApplicationPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForeignCurrency");

            migrationBuilder.DropTable(
                name: "NewsSectionNews");

            migrationBuilder.DropTable(
                name: "PromotionNews");

            migrationBuilder.DropTable(
                name: "Remittences");

            migrationBuilder.DropTable(
                name: "RequiredDocuments");

            migrationBuilder.DropTable(
                name: "UserGuides");

            migrationBuilder.DropTable(
                name: "ValueAddedBenifits");

            migrationBuilder.DropTable(
                name: "NewsSections");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Corporate");

            migrationBuilder.DropTable(
                name: "ApplicationPages");
        }
    }
}
