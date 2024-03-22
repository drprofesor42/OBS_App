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
<<<<<<<< HEAD:OBS_App/Migrations/20240308114246_init.Designer.cs
    [Migration("20240308114246_init")]
    partial class init
========
<<<<<<<< HEAD:OBS_App/Migrations/20240307182322_denme.Designer.cs
    [Migration("20240307182322_denme")]
    partial class denme
========
    [Migration("20240307141739_init")]
    partial class init
>>>>>>>> kagan:OBS_App/Migrations/20240307141739_init.Designer.cs
>>>>>>>> 405cea934c578e9f7a35764583885fa6e27ab09b:OBS_App/Migrations/20240307182322_denme.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("OBS_App.Data.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("adminId"));

                    b.Property<string>("adminEposta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("adminIsim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("adminParola")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("adminSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("adminId");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("OBS_App.Data.AkademikTakvim", b =>
                {
                    b.Property<int>("akademikTakvimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("akademikTakvimId"));

                    b.Property<string>("akademikTakvimAktivite")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("akademikTakvimBaslangic")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("akademikTakvimBitis")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("akademikTakvimId");

                    b.ToTable("AkademikTakvimler");
                });

            modelBuilder.Entity("OBS_App.Data.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BolumBaskani")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BolumIsmi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OgrenciSayisi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("OBS_App.Data.Ders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("dersAkts")
                        .HasColumnType("int");

                    b.Property<string>("dersIsim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dersKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("dersKredi")
                        .HasColumnType("int");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("profesorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("OBS_App.Data.Duyuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("duyuruBaslık")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("duyuruGondericiAdmin")
                        .HasColumnType("int");

                    b.Property<int>("duyuruGondericiProf")
                        .HasColumnType("int");

                    b.Property<string>("duyuruMesaj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("olusturmaTarihi")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Duyurular");
                });

            modelBuilder.Entity("OBS_App.Data.DuyuruAlici", b =>
                {
                    b.Property<int>("duyuruAliciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("duyuruAliciId"));

                    b.Property<DateOnly>("duyuruAliciOlusturmaTarihi")
                        .HasColumnType("date");
<<<<<<<< HEAD:OBS_App/Migrations/20240308114246_init.Designer.cs
========
>>>>>>>> kagan:OBS_App/Migrations/20240307141739_init.Designer.cs
>>>>>>>> 405cea934c578e9f7a35764583885fa6e27ab09b:OBS_App/Migrations/20240307182322_denme.Designer.cs

                    b.Property<int>("duyuruAlici_ogrenci")
                        .HasColumnType("int");

                    b.Property<int>("duyuruId")
                        .HasColumnType("int");

                    b.HasKey("duyuruAliciId");

<<<<<<<< HEAD:OBS_App/Migrations/20240308114246_init.Designer.cs
========
<<<<<<<< HEAD:OBS_App/Migrations/20240307182322_denme.Designer.cs
                    b.HasIndex("OgrencisId");

                    b.HasIndex("duyuruId");

========
>>>>>>>> kagan:OBS_App/Migrations/20240307141739_init.Designer.cs
>>>>>>>> 405cea934c578e9f7a35764583885fa6e27ab09b:OBS_App/Migrations/20240307182322_denme.Designer.cs
                    b.ToTable("DuyuruAlicilar");
                });

            modelBuilder.Entity("OBS_App.Data.Fakulte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("fakulteIsim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("fakulteProfId")
                        .HasColumnType("int");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Fakulteler");
                });

            modelBuilder.Entity("OBS_App.Data.FakulteBolum", b =>
                {
                    b.Property<int>("fakulteBolumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("fakulteBolumId"));

                    b.Property<int>("bolumId")
                        .HasColumnType("int");

                    b.Property<int>("fakulteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("fakulteBolumId");

                    b.ToTable("FakulteBolumler");
                });

            modelBuilder.Entity("OBS_App.Data.OgrenciDers", b =>
                {
                    b.Property<int>("ogrenciDersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ogrenciDersId"));

                    b.Property<int>("dersFinalSonuc")
                        .HasColumnType("int");

                    b.Property<int>("dersId")
                        .HasColumnType("int");

                    b.Property<int>("dersSinavSonuc1")
                        .HasColumnType("int");

                    b.Property<int>("dersSinavSonuc2")
                        .HasColumnType("int");

                    b.Property<int>("ogrenciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ogrenciDersId");

                    b.HasIndex("dersId");

                    b.ToTable("OgrenciDersler");
                });

            modelBuilder.Entity("OBS_App.Data.OgrenciMesaj", b =>
                {
                    b.Property<int>("ogrenciMesajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ogrenciMesajId"));

                    b.Property<int>("ogrenciMesajAlici")
                        .HasColumnType("int");

                    b.Property<int>("ogrenciMesajGonderici")
                        .HasColumnType("int");

                    b.Property<string>("ogrenciMesajMesaj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("olusturmaTarihi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ogrenciMesajId");

                    b.ToTable("ogrenciMesajlar");
                });

            modelBuilder.Entity("OBS_App.Data.Ogrencis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DogumTarihi")
                        .HasColumnType("date");

                    b.Property<string>("Eposta")
                        .HasColumnType("longtext");

                    b.Property<int>("TelefonNo")
                        .HasColumnType("int");

                    b.Property<DateOnly>("kayitTarihi")
                        .HasColumnType("date");

                    b.Property<string>("ogrenciAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ogrenciBolum")
                        .HasColumnType("int");

                    b.Property<string>("ogrenciCinsiyet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ogrenciDanisman")
                        .HasColumnType("int");

                    b.Property<int>("ogrenciNo")
                        .HasColumnType("int");

                    b.Property<string>("ogrenciParola")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ogrenciSinif")
                        .HasColumnType("int");

                    b.Property<string>("ogrenciSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ogrenciTc")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("OBS_App.Data.Ogretmens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<int>("OgretmenNumarasi")
                        .HasColumnType("int");

                    b.Property<string>("OgretmenOfis")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenParola")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenParolaOnayla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenSehir")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenSoyad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenUlke")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenUnvan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OgretmenUsername")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ogretmenler");
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

<<<<<<<< HEAD:OBS_App/Migrations/20240308114246_init.Designer.cs
========
<<<<<<<< HEAD:OBS_App/Migrations/20240307182322_denme.Designer.cs
            modelBuilder.Entity("OBS_App.Data.Duyuru", b =>
                {
                    b.HasOne("OBS_App.Data.Ogretmens", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("OBS_App.Data.DuyuruAlici", b =>
                {
                    b.HasOne("OBS_App.Data.Ogrencis", "Ogrencis")
                        .WithMany()
                        .HasForeignKey("OgrencisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBS_App.Data.Duyuru", "Duyuru")
                        .WithMany()
                        .HasForeignKey("duyuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duyuru");

                    b.Navigation("Ogrencis");
========
            modelBuilder.Entity("OBS_App.Data.FakulteBolum", b =>
                {
                    b.HasOne("OBS_App.Data.Bolum", null)
                        .WithOne("FakulteBolum")
                        .HasForeignKey("OBS_App.Data.FakulteBolum", "bolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
>>>>>>>> kagan:OBS_App/Migrations/20240307141739_init.Designer.cs
                });

>>>>>>>> 405cea934c578e9f7a35764583885fa6e27ab09b:OBS_App/Migrations/20240307182322_denme.Designer.cs
            modelBuilder.Entity("OBS_App.Data.OgrenciDers", b =>
                {
                    b.HasOne("OBS_App.Data.Ders", "Ders")
                        .WithMany()
                        .HasForeignKey("dersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");
                });
#pragma warning restore 612, 618
        }
    }
}