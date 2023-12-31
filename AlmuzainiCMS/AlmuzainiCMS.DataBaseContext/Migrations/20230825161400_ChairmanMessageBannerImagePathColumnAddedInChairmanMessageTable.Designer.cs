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
    [Migration("20230825161400_ChairmanMessageBannerImagePathColumnAddedInChairmanMessageTable")]
    partial class ChairmanMessageBannerImagePathColumnAddedInChairmanMessageTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("ValuesItem1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValuesItem9")
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
#pragma warning restore 612, 618
        }
    }
}
