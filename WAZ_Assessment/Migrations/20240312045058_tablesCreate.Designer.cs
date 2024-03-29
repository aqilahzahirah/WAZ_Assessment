﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAZ_Assessment;

#nullable disable

namespace WAZ_Assessment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240312045058_tablesCreate")]
    partial class tablesCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WAZ_Assessment.Models.Login", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.Platform", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<double?>("latitude")
                        .HasColumnType("float");

                    b.Property<double?>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("uniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.PlatformDummy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("uniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("wellid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("wellid");

                    b.ToTable("PlatformDummy");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.Well", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<double?>("latitude")
                        .HasColumnType("float");

                    b.Property<double?>("longitude")
                        .HasColumnType("float");

                    b.Property<int>("platformId")
                        .HasColumnType("int");

                    b.Property<string>("uniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("platformId");

                    b.ToTable("Well");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.WellDummy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<int>("platformId")
                        .HasColumnType("int");

                    b.Property<string>("uniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("WellDummy");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.PlatformDummy", b =>
                {
                    b.HasOne("WAZ_Assessment.Models.WellDummy", "well")
                        .WithMany()
                        .HasForeignKey("wellid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("well");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.Well", b =>
                {
                    b.HasOne("WAZ_Assessment.Models.Platform", "Platform")
                        .WithMany("well")
                        .HasForeignKey("platformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("WAZ_Assessment.Models.Platform", b =>
                {
                    b.Navigation("well");
                });
#pragma warning restore 612, 618
        }
    }
}
