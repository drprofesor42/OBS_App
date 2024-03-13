﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBS_App.Models;

#nullable disable

namespace OBS_App.Migrations
{
    [DbContext(typeof(IdentityDataContext))]
    partial class IdentityDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OBS_App.Data.AkademikTakvim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AkademikTakvimAktivite")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("AkademikTakvimBaslangic")
                        .HasColumnType("date");

                    b.Property<DateOnly>("AkademikTakvimBitis")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("AkademikTakvimler");
                });

            modelBuilder.Entity("OBS_App.Data.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BolumAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BolumBaskani")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FakulteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FakulteId");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("OBS_App.Data.Ders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BolumId")
                        .HasColumnType("int");

                    b.Property<string>("DersAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DersAkts")
                        .HasColumnType("int");

                    b.Property<string>("DersKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DersKredi")
                        .HasColumnType("int");

                    b.Property<int?>("OgretmensId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OlusturmaTarihi")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.HasIndex("OgretmensId");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("OBS_App.Data.DersOgrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("OgrencisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DersId");

                    b.HasIndex("OgrencisId");

                    b.ToTable("DersOgrenciler");
                });

            modelBuilder.Entity("OBS_App.Data.Donem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DonemAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DonemYariyil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Donemler");
                });

            modelBuilder.Entity("OBS_App.Data.Duyuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DuyuruBaslik")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DuyuruMesaj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OgretmenId")
                        .HasColumnType("int");

                    b.Property<int?>("OgretmensId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OlusturmaTarihi")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("OgretmensId");

                    b.ToTable("Duyurular");
                });

            modelBuilder.Entity("OBS_App.Data.Fakulte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FakulteAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FakulteOgrenciSayisi")
                        .HasColumnType("int");

                    b.Property<int>("FakulteOgretmenSayisi")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OlusturmaTarihi")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Fakulteler");
                });

            modelBuilder.Entity("OBS_App.Data.Not", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("NotFinal")
                        .HasColumnType("int");

                    b.Property<int>("NotOdev")
                        .HasColumnType("int");

                    b.Property<DateOnly>("NotTarihi")
                        .HasColumnType("date");

                    b.Property<int>("NotVize")
                        .HasColumnType("int");

                    b.Property<int?>("OgrencisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DersId");

                    b.HasIndex("OgrencisId");

                    b.ToTable("Notlar");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BolumId")
                        .HasColumnType("int");

                    b.Property<int?>("DersId")
                        .HasColumnType("int");

                    b.Property<int?>("FakulteId")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciAdres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OgrenciCinsiyet")
                        .HasColumnType("int");

                    b.Property<int>("OgrenciDanisman")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OgrenciDogumTarihi")
                        .HasColumnType("date");

                    b.Property<string>("OgrenciEposta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("OgrenciKayitTarihi")
                        .HasColumnType("date");

                    b.Property<int>("OgrenciNo")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciParola")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OgrenciSinif")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciTc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciTelefon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.HasIndex("DersId");

                    b.HasIndex("FakulteId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("OBS_App.Data.OgretmenOgrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OgrencisId")
                        .HasColumnType("int");

                    b.Property<int>("OgretmensId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OgrencisId");

                    b.HasIndex("OgretmensId");

                    b.ToTable("OgretmenOgrenciler");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BolumId")
                        .HasColumnType("int");

                    b.Property<int?>("FakulteId")
                        .HasColumnType("int");

                    b.Property<string>("OgretmenAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenAdres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("OgretmenBaslamaTarihi")
                        .HasColumnType("date");

                    b.Property<string>("OgretmenCinsiyet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("OgretmenDogumTarihi")
                        .HasColumnType("date");

                    b.Property<string>("OgretmenEposta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenGorusme")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenOfis")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenParola")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenTelefon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenUnvan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.HasIndex("FakulteId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("OBS_App.Data.OkulDonemDers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolumId")
                        .HasColumnType("int");

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("DonemId")
                        .HasColumnType("int");

                    b.Property<int>("FakulteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.HasIndex("DersId");

                    b.HasIndex("DonemId");

                    b.HasIndex("FakulteId");

                    b.ToTable("OkulDonemDersler");
                });

            modelBuilder.Entity("OBS_App.Models.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("OBS_App.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("OBS_App.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OBS_App.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OBS_App.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("OBS_App.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OBS_App.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OBS_App.Data.Bolum", b =>
                {
                    b.HasOne("OBS_App.Data.Fakulte", "Fakulte")
                        .WithMany("Bolumler")
                        .HasForeignKey("FakulteId");

                    b.Navigation("Fakulte");
                });

            modelBuilder.Entity("OBS_App.Data.Ders", b =>
                {
                    b.HasOne("OBS_App.Data.Bolum", "Bolum")
                        .WithMany("Dersler")
                        .HasForeignKey("BolumId");

                    b.HasOne("OBS_App.Data.Ogretmens", "Ogretmens")
                        .WithMany("Dersler")
                        .HasForeignKey("OgretmensId");

                    b.Navigation("Bolum");

                    b.Navigation("Ogretmens");
                });

            modelBuilder.Entity("OBS_App.Data.DersOgrenci", b =>
                {
                    b.HasOne("OBS_App.Data.Ders", "Ders")
                        .WithMany("DersOgrenciler")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Ogrencis", "Ogrencis")
                        .WithMany("DersOgrenciler")
                        .HasForeignKey("OgrencisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Ogrencis");
                });

            modelBuilder.Entity("OBS_App.Data.Duyuru", b =>
                {
                    b.HasOne("OBS_App.Data.Ogretmens", "Ogretmens")
                        .WithMany("Duyurular")
                        .HasForeignKey("OgretmensId");

                    b.Navigation("Ogretmens");
                });

            modelBuilder.Entity("OBS_App.Data.Not", b =>
                {
                    b.HasOne("OBS_App.Data.Ders", "Ders")
                        .WithMany("notlar")
                        .HasForeignKey("DersId");

                    b.HasOne("OBS_App.Data.Ogrencis", "Ogrencis")
                        .WithMany()
                        .HasForeignKey("OgrencisId");

                    b.Navigation("Ders");

                    b.Navigation("Ogrencis");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.HasOne("OBS_App.Data.Bolum", "Bolum")
                        .WithMany("Ogrencisler")
                        .HasForeignKey("BolumId");

                    b.HasOne("OBS_App.Data.Ders", null)
                        .WithMany("Ogrencis")
                        .HasForeignKey("DersId");

                    b.HasOne("OBS_App.Data.Fakulte", null)
                        .WithMany("Ogrencisler")
                        .HasForeignKey("FakulteId");

                    b.Navigation("Bolum");
                });

            modelBuilder.Entity("OBS_App.Data.OgretmenOgrenci", b =>
                {
                    b.HasOne("OBS_App.Data.Ogrencis", "Ogrencis")
                        .WithMany("OgretmenOgrenciler")
                        .HasForeignKey("OgrencisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Ogretmens", "Ogretmens")
                        .WithMany("OgretmenOgrenciler")
                        .HasForeignKey("OgretmensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogrencis");

                    b.Navigation("Ogretmens");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.HasOne("OBS_App.Data.Bolum", null)
                        .WithMany("Ogretmensler")
                        .HasForeignKey("BolumId");

                    b.HasOne("OBS_App.Data.Fakulte", null)
                        .WithMany("Ogretmensler")
                        .HasForeignKey("FakulteId");
                });

            modelBuilder.Entity("OBS_App.Data.OkulDonemDers", b =>
                {
                    b.HasOne("OBS_App.Data.Bolum", "Bolum")
                        .WithMany("OkulDonemDersler")
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Ders", "Ders")
                        .WithMany("OkulDonemDersler")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Donem", "Donem")
                        .WithMany("OkulDonemDers")
                        .HasForeignKey("DonemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Fakulte", "Fakulte")
                        .WithMany("OkulDonemDersler")
                        .HasForeignKey("FakulteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");

                    b.Navigation("Ders");

                    b.Navigation("Donem");

                    b.Navigation("Fakulte");
                });

            modelBuilder.Entity("OBS_App.Data.Bolum", b =>
                {
                    b.Navigation("Dersler");

                    b.Navigation("Ogrencisler");

                    b.Navigation("Ogretmensler");

                    b.Navigation("OkulDonemDersler");
                });

            modelBuilder.Entity("OBS_App.Data.Ders", b =>
                {
                    b.Navigation("DersOgrenciler");

                    b.Navigation("Ogrencis");

                    b.Navigation("OkulDonemDersler");

                    b.Navigation("notlar");
                });

            modelBuilder.Entity("OBS_App.Data.Donem", b =>
                {
                    b.Navigation("OkulDonemDers");
                });

            modelBuilder.Entity("OBS_App.Data.Fakulte", b =>
                {
                    b.Navigation("Bolumler");

                    b.Navigation("Ogrencisler");

                    b.Navigation("Ogretmensler");

                    b.Navigation("OkulDonemDersler");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.Navigation("DersOgrenciler");

                    b.Navigation("OgretmenOgrenciler");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.Navigation("Dersler");

                    b.Navigation("Duyurular");

                    b.Navigation("OgretmenOgrenciler");
                });
#pragma warning restore 612, 618
        }
    }
}
