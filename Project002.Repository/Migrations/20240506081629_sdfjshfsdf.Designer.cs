﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project002.Repository.Models;

#nullable disable

namespace Project002.Repository.Migrations
{
    [DbContext(typeof(Dbcontext))]
    [Migration("20240506081629_sdfjshfsdf")]
    partial class sdfjshfsdf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArmourSamurai", b =>
                {
                    b.Property<int>("ArmourId")
                        .HasColumnType("int");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("ArmourId", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("ArmourSamurai");
                });

            modelBuilder.Entity("ClanWar", b =>
                {
                    b.Property<int>("ClansClanId")
                        .HasColumnType("int");

                    b.Property<int>("WarsWarId")
                        .HasColumnType("int");

                    b.HasKey("ClansClanId", "WarsWarId");

                    b.HasIndex("WarsWarId");

                    b.ToTable("ClanWar");
                });

            modelBuilder.Entity("ClothingSamurai", b =>
                {
                    b.Property<int>("ClothingId")
                        .HasColumnType("int");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("ClothingId", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("ClothingSamurai");
                });

            modelBuilder.Entity("Project002.Repository.Models.Armour", b =>
                {
                    b.Property<int?>("ArmourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ArmourId"), 1L, 1);

                    b.Property<string>("ArmourDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArmourName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArmourId");

                    b.ToTable("Armour");
                });

            modelBuilder.Entity("Project002.Repository.Models.Clan", b =>
                {
                    b.Property<int?>("ClanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ClanId"), 1L, 1);

                    b.Property<string>("ClanName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClanId");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("Project002.Repository.Models.Clothing", b =>
                {
                    b.Property<int>("ClothingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClothingId"), 1L, 1);

                    b.Property<string>("ClothingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClothingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClothingId");

                    b.ToTable("Clothing");
                });

            modelBuilder.Entity("Project002.Repository.Models.Horse", b =>
                {
                    b.Property<int?>("HorseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("HorseId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("HorseId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Horse");
                });

            modelBuilder.Entity("Project002.Repository.Models.Rank", b =>
                {
                    b.Property<int?>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RankId"), 1L, 1);

                    b.Property<string>("RankName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RankId");

                    b.ToTable("Rank");
                });

            modelBuilder.Entity("Project002.Repository.Models.Samurai", b =>
                {
                    b.Property<int>("SamuraiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SamuraiId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("ClanId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RankId")
                        .HasColumnType("int");

                    b.Property<string>("SamuraiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SamuraiId");

                    b.HasIndex("ClanId");

                    b.HasIndex("RankId");

                    b.ToTable("Samurai");
                });

            modelBuilder.Entity("Project002.Repository.Models.TimePeriod", b =>
                {
                    b.Property<int>("TimePeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimePeriodId"), 1L, 1);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimePeriodId");

                    b.ToTable("TimePeriod");
                });

            modelBuilder.Entity("Project002.Repository.Models.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Project002.Repository.Models.War", b =>
                {
                    b.Property<int?>("WarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("WarId"), 1L, 1);

                    b.Property<int?>("DeathCount")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarId");

                    b.ToTable("War");
                });

            modelBuilder.Entity("Project002.Repository.Models.Weapon", b =>
                {
                    b.Property<int?>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("WeaponId"), 1L, 1);

                    b.Property<string>("WeaponName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("SamuraiWar", b =>
                {
                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<int>("WarId")
                        .HasColumnType("int");

                    b.HasKey("SamuraiId", "WarId");

                    b.HasIndex("WarId");

                    b.ToTable("SamuraiWar");
                });

            modelBuilder.Entity("SamuraiWeapon", b =>
                {
                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("SamuraiId", "WeaponId");

                    b.HasIndex("WeaponId");

                    b.ToTable("SamuraiWeapon");
                });

            modelBuilder.Entity("TimePeriodWar", b =>
                {
                    b.Property<int>("TimePeriodId")
                        .HasColumnType("int");

                    b.Property<int>("WarId")
                        .HasColumnType("int");

                    b.HasKey("TimePeriodId", "WarId");

                    b.HasIndex("WarId");

                    b.ToTable("TimePeriodWar");
                });

            modelBuilder.Entity("ArmourSamurai", b =>
                {
                    b.HasOne("Project002.Repository.Models.Armour", null)
                        .WithMany()
                        .HasForeignKey("ArmourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project002.Repository.Models.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClanWar", b =>
                {
                    b.HasOne("Project002.Repository.Models.Clan", null)
                        .WithMany()
                        .HasForeignKey("ClansClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project002.Repository.Models.War", null)
                        .WithMany()
                        .HasForeignKey("WarsWarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClothingSamurai", b =>
                {
                    b.HasOne("Project002.Repository.Models.Clothing", null)
                        .WithMany()
                        .HasForeignKey("ClothingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project002.Repository.Models.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project002.Repository.Models.Horse", b =>
                {
                    b.HasOne("Project002.Repository.Models.Samurai", "Samurai")
                        .WithMany("Horse")
                        .HasForeignKey("SamuraiId");

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("Project002.Repository.Models.Samurai", b =>
                {
                    b.HasOne("Project002.Repository.Models.Clan", "Clan")
                        .WithMany("Samurai")
                        .HasForeignKey("ClanId");

                    b.HasOne("Project002.Repository.Models.Rank", "Rank")
                        .WithMany("Samurai")
                        .HasForeignKey("RankId");

                    b.Navigation("Clan");

                    b.Navigation("Rank");
                });

            modelBuilder.Entity("SamuraiWar", b =>
                {
                    b.HasOne("Project002.Repository.Models.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project002.Repository.Models.War", null)
                        .WithMany()
                        .HasForeignKey("WarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SamuraiWeapon", b =>
                {
                    b.HasOne("Project002.Repository.Models.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project002.Repository.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimePeriodWar", b =>
                {
                    b.HasOne("Project002.Repository.Models.TimePeriod", null)
                        .WithMany()
                        .HasForeignKey("TimePeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project002.Repository.Models.War", null)
                        .WithMany()
                        .HasForeignKey("WarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project002.Repository.Models.Clan", b =>
                {
                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("Project002.Repository.Models.Rank", b =>
                {
                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("Project002.Repository.Models.Samurai", b =>
                {
                    b.Navigation("Horse");
                });
#pragma warning restore 612, 618
        }
    }
}
