﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBS_App.Models;

#nullable disable

namespace OBS_App.Migrations
{
    [DbContext(typeof(IdentityDataContext))]
<<<<<<<< HEAD:OBS_App/Migrations/20240315065246_init.Designer.cs
    [Migration("20240315065246_init")]
    partial class init
========
    [Migration("20240315074122_asdasdlşjkş")]
    partial class asdasdlşjkş
>>>>>>>> Bilimist:OBS_App/Migrations/20240315074122_asdasdlşjkş.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DersOgrencis", b =>
                {
                    b.Property<int>("DerslerId")
                        .HasColumnType("int");

                    b.Property<int>("OgrencislerId")
                        .HasColumnType("int");

                    b.HasKey("DerslerId", "OgrencislerId");

                    b.HasIndex("OgrencislerId");

                    b.ToTable("DersOgrencis");
                });

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

            modelBuilder.Entity("OBS_App.Data.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcıkAdres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ilce")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sehir")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ulke")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Adresler");
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

                    b.Property<int?>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FakulteId");

                    b.HasIndex("SinifId");

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

                    b.Property<string>("DersAkts")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DersKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DersKredi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FakulteId")
                        .HasColumnType("int");

                    b.Property<int?>("OgretmensId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OlusturmaTarihi")
                        .HasColumnType("date");

                    b.Property<int?>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.HasIndex("FakulteId");

                    b.HasIndex("OgretmensId");

                    b.HasIndex("SinifId");

                    b.ToTable("Dersler");
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

                    b.Property<string>("DuyuruGonderen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DuyuruMesaj")
                        .IsRequired()
                        .HasColumnType("longtext");

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

                    b.Property<int>("FakulteDersSayisi")
                        .HasColumnType("int");

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

                    b.Property<int?>("NotFinal")
                        .HasColumnType("int");

                    b.Property<int?>("NotOdev")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("NotTarihi")
                        .HasColumnType("date");

                    b.Property<int?>("NotVize")
                        .HasColumnType("int");

                    b.Property<int>("OgrencisId")
                        .HasColumnType("int");

                    b.Property<int?>("OgretmensId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DersId");

                    b.HasIndex("OgrencisId");

                    b.HasIndex("OgretmensId");

                    b.ToTable("Notlar");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<int?>("BolumId")
                        .HasColumnType("int");

                    b.Property<int?>("FakulteId")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciCinsiyet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciDanisman")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("OgrenciDogumTarihi")
                        .HasColumnType("date");

                    b.Property<string>("OgrenciEposta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("OgrenciKayitTarihi")
                        .HasColumnType("date");

                    b.Property<string>("OgrenciParola")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciParolaOnayla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OgrenciSinif")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgrenciTc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("OgrenciTelefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int?>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("BolumId");

                    b.HasIndex("FakulteId");

                    b.HasIndex("SinifId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<int?>("BolumId")
                        .HasColumnType("int");

                    b.Property<int?>("FakulteId")
                        .HasColumnType("int");

                    b.Property<string>("OgretmenAd")
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

                    b.Property<string>("OgretmenParolaOnayla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenTelefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("OgretmenUnvan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("BolumId");

                    b.HasIndex("FakulteId");

                    b.HasIndex("SinifId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("OBS_App.Data.Sinif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DonemId")
                        .HasColumnType("int");

                    b.Property<string>("SinifNumarasi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DonemId");

                    b.ToTable("Siniflar");
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

                    b.Property<string>("DuyuruName")
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

            modelBuilder.Entity("OgrencisOgretmens", b =>
                {
                    b.Property<int>("OgrencislerId")
                        .HasColumnType("int");

                    b.Property<int>("OgretmenslerId")
                        .HasColumnType("int");

                    b.HasKey("OgrencislerId", "OgretmenslerId");

                    b.HasIndex("OgretmenslerId");

                    b.ToTable("OgrencisOgretmens");
                });

            modelBuilder.Entity("DersOgrencis", b =>
                {
                    b.HasOne("OBS_App.Data.Ders", null)
                        .WithMany()
                        .HasForeignKey("DerslerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Ogrencis", null)
                        .WithMany()
                        .HasForeignKey("OgrencislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.HasOne("OBS_App.Data.Sinif", null)
                        .WithMany("Bolumler")
                        .HasForeignKey("SinifId");

                    b.Navigation("Fakulte");
                });

            modelBuilder.Entity("OBS_App.Data.Ders", b =>
                {
                    b.HasOne("OBS_App.Data.Bolum", "Bolum")
                        .WithMany("Dersler")
                        .HasForeignKey("BolumId");

                    b.HasOne("OBS_App.Data.Fakulte", null)
                        .WithMany("Dersler")
                        .HasForeignKey("FakulteId");

                    b.HasOne("OBS_App.Data.Ogretmens", "Ogretmens")
                        .WithMany("Dersler")
                        .HasForeignKey("OgretmensId");

                    b.HasOne("OBS_App.Data.Sinif", null)
                        .WithMany("Dersler")
                        .HasForeignKey("SinifId");

                    b.Navigation("Bolum");

                    b.Navigation("Ogretmens");
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
                        .WithMany("Notlar")
                        .HasForeignKey("OgrencisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Ogretmens", "Ogretmens")
                        .WithMany("Notlar")
                        .HasForeignKey("OgretmensId");

                    b.Navigation("Ders");

                    b.Navigation("Ogrencis");

                    b.Navigation("Ogretmens");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.HasOne("OBS_App.Data.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Bolum", "Bolum")
                        .WithMany("Ogrencisler")
                        .HasForeignKey("BolumId");

                    b.HasOne("OBS_App.Data.Fakulte", "Fakulte")
                        .WithMany("Ogrencisler")
                        .HasForeignKey("FakulteId");

                    b.HasOne("OBS_App.Data.Sinif", null)
                        .WithMany("Ogrencisler")
                        .HasForeignKey("SinifId");

                    b.Navigation("Adres");

                    b.Navigation("Bolum");

                    b.Navigation("Fakulte");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.HasOne("OBS_App.Data.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Bolum", "Bolum")
                        .WithMany("Ogretmensler")
                        .HasForeignKey("BolumId");

                    b.HasOne("OBS_App.Data.Fakulte", "Fakulte")
                        .WithMany("Ogretmensler")
                        .HasForeignKey("FakulteId");

                    b.HasOne("OBS_App.Data.Sinif", null)
                        .WithMany("Ogretmensler")
                        .HasForeignKey("SinifId");

                    b.Navigation("Adres");

                    b.Navigation("Bolum");

                    b.Navigation("Fakulte");
                });

            modelBuilder.Entity("OBS_App.Data.Sinif", b =>
                {
                    b.HasOne("OBS_App.Data.Donem", "Donem")
                        .WithMany("Siniflar")
                        .HasForeignKey("DonemId");

                    b.Navigation("Donem");
                });

            modelBuilder.Entity("OgrencisOgretmens", b =>
                {
                    b.HasOne("OBS_App.Data.Ogrencis", null)
                        .WithMany()
                        .HasForeignKey("OgrencislerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Ogretmens", null)
                        .WithMany()
                        .HasForeignKey("OgretmenslerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OBS_App.Data.Bolum", b =>
                {
                    b.Navigation("Dersler");

                    b.Navigation("Ogrencisler");

                    b.Navigation("Ogretmensler");
                });

            modelBuilder.Entity("OBS_App.Data.Ders", b =>
                {
                    b.Navigation("notlar");
                });

            modelBuilder.Entity("OBS_App.Data.Donem", b =>
                {
                    b.Navigation("Siniflar");
                });

            modelBuilder.Entity("OBS_App.Data.Fakulte", b =>
                {
                    b.Navigation("Bolumler");

                    b.Navigation("Dersler");

                    b.Navigation("Ogrencisler");

                    b.Navigation("Ogretmensler");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.Navigation("Notlar");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.Navigation("Dersler");

                    b.Navigation("Duyurular");

                    b.Navigation("Notlar");
                });

            modelBuilder.Entity("OBS_App.Data.Sinif", b =>
                {
                    b.Navigation("Bolumler");

                    b.Navigation("Dersler");

                    b.Navigation("Ogrencisler");

                    b.Navigation("Ogretmensler");
                });
#pragma warning restore 612, 618
        }
    }
}
