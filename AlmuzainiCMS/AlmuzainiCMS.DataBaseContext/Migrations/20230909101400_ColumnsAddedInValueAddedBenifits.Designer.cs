﻿// <auto-generated />
using System;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlmuzainiCMS.DataBaseContext.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20230909101400_ColumnsAddedInValueAddedBenifits")]
    partial class ColumnsAddedInValueAddedBenifits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ApplicationPage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ABoutBoxDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionFourthDescriptionSectionOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionFourthDescriptionSectionTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionFourthImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionFourthTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionOneDescriptionSectionOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionOneDescriptionSectionTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionOneImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionOneTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionThreeDescriptionSectionOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionThreeDescriptionSectionTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionThreeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionThreeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionTwoDescriptionSectionOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionTwoDescriptionSectionTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionTwoImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppFeaturesSectionTwoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppGalleryIconImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppTutorialsSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplePlayStoreIconImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconFiveImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconFiveTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconFourImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconFourTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconOneImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconOneTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconSixImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconSixTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconThreeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconThreeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconTwoImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIconTwoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GooglePlayStoreIconImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderFourImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderOneImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderThreeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderTwoImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserGuideTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoFiveLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoFiveTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoFourLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoFourTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoOneLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoOneTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoThreeLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoThreeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoTwoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoTwoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationPages");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ChairmanMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChairmanImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChairmanMessageBannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChairmanName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FifthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeventhSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SixthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdSection")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChairmanMessage");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.CompanyHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyHistoryImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyProfileBannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpertiseImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpertiseText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologyImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologyText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkforceImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkforceText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompanyHistory");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.Corporate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactsText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporateClientsText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequiredDocumentsText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderFourImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderOneImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderThreeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderTwoImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Corporate");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.CorporateSocialResponsibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CorporateSocialResponsibilityImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FifthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeventhSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SixthSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdSection")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CorporateSocialResponsibilities");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.CurrencyCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrencyCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("flagPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurrenyCodes");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.CurrencyRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyRequests");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ForeignCurrency", b =>
                {
                    b.Property<string>("CashCurrencyBannerImagePath")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BranchImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuySellCurrencyLinkOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuySellCurrencyLinkOneText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuySellCurrencyLinkTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuySellCurrencyLinkTwoText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuySellCurrencyORText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuySellCurrencyText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FCDeliveryImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FCDeliveryText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FCExchangeTextFirstSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FCExchangeTextSecondSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FCExchangeTextThirdSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionPageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionPageHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ORDescriptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QRCodeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlideImageFileFourPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlideImageFileOnePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlideImageFileThreePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlideImageFileTwoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CashCurrencyBannerImagePath");

                    b.ToTable("ForeignCurrency");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.GetTTRateResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("currencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fcAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lcAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GetTrateResults");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.MissionVisionValues", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MissionImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MissionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MissionVisionBannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisionImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MissionVisionValues");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.NewsSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewsSections");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.NewsSectionNews", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NewsSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NewsSectionId");

                    b.ToTable("NewsSectionNews");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.PromotionNews", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PromotionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionNews");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.Remittences", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSectionLeftImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSectionLeftText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSectionLeftTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSectionRightImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSectionRightText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstSectionRightTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSectionLeftText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSectionLeftTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSectionRightText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthSectionRightTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemitNowImageOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemitNowImageOneText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemitNowImageTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemitNowImageTwoText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemitNowText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSectionImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSectionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderFourImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderOneImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderThreeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderTwoImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdSectionImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdSectionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoOneLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoOneText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoOneThumbnailImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoTwoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoTwoText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoTwoThumbnailImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Remittences");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.RequiredDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorporateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RequiredDocumentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorporateId");

                    b.ToTable("RequiredDocuments");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.UserGuide", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationPageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.Property<string>("UserGuideText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationPageId");

                    b.ToTable("UserGuides");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.UsersInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("userCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userCreateDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("userPass")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("userPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usersInfos");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ValueAddedBenifits", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerSectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionFirstImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionFirstText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionFirstTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionSecondImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionSecondText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionSecondTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionThirdImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionThirdText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSectionThirdTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionFirstImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionFirstText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionFirstTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionFourthImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionFourthText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionFourthTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionSecondImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionSecondText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionSecondTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionThirdImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionThirdText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightSectionThirdTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValueAddedBenifits");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ValuesItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MissionVisionValuesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.Property<string>("ValuesItemText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MissionVisionValuesId");

                    b.ToTable("ValuesItems");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.NewsSectionNews", b =>
                {
                    b.HasOne("AlmuzainiCMS.Models.Models.NewsSection", "NewsSection")
                        .WithMany("NewsSectionNews")
                        .HasForeignKey("NewsSectionId");

                    b.Navigation("NewsSection");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.PromotionNews", b =>
                {
                    b.HasOne("AlmuzainiCMS.Models.Models.Promotion", "Promotion")
                        .WithMany("PromotionNews")
                        .HasForeignKey("PromotionId");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.RequiredDocument", b =>
                {
                    b.HasOne("AlmuzainiCMS.Models.Models.Corporate", "Corporate")
                        .WithMany("RequiredDocuments")
                        .HasForeignKey("CorporateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corporate");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.UserGuide", b =>
                {
                    b.HasOne("AlmuzainiCMS.Models.Models.ApplicationPage", "Application")
                        .WithMany("UserGuides")
                        .HasForeignKey("ApplicationPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ValuesItem", b =>
                {
                    b.HasOne("AlmuzainiCMS.Models.Models.MissionVisionValues", "MissionVisionValues")
                        .WithMany("ValuesItems")
                        .HasForeignKey("MissionVisionValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MissionVisionValues");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.ApplicationPage", b =>
                {
                    b.Navigation("UserGuides");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.Corporate", b =>
                {
                    b.Navigation("RequiredDocuments");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.MissionVisionValues", b =>
                {
                    b.Navigation("ValuesItems");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.NewsSection", b =>
                {
                    b.Navigation("NewsSectionNews");
                });

            modelBuilder.Entity("AlmuzainiCMS.Models.Models.Promotion", b =>
                {
                    b.Navigation("PromotionNews");
                });
#pragma warning restore 612, 618
        }
    }
}
