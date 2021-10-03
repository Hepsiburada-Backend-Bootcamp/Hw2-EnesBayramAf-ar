﻿// <auto-generated />
using System;
using Hw2_EnesBayramAfşar.VT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hw2_EnesBayramAfşar.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211003105932_EkleBirebirİliskiKitapDetay")]
    partial class EkleBirebirİliskiKitapDetay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.Kitap", b =>
                {
                    b.Property<int>("KitapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KitapDetayId")
                        .HasColumnType("int");

                    b.Property<double>("KitapFiyat")
                        .HasColumnType("float");

                    b.HasKey("KitapId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("KitapDetayId")
                        .IsUnique();

                    b.ToTable("tb_Kitap");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.KitapDetay", b =>
                {
                    b.Property<int>("KitapDetayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BolumSayisi")
                        .HasColumnType("int");

                    b.Property<double>("KitapAgirlik")
                        .HasColumnType("float");

                    b.Property<int>("KitapSayfasi")
                        .HasColumnType("int");

                    b.HasKey("KitapDetayId");

                    b.ToTable("KitapDetay");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.Tur", b =>
                {
                    b.Property<int>("TurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TurAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurId");

                    b.ToTable("Turler");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.YayınEvi", b =>
                {
                    b.Property<int>("YayinEvi_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YayinEviAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YayinEvi_Id");

                    b.ToTable("tb_YayinEvi");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.Yazar", b =>
                {
                    b.Property<int>("Yazar_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("YazarAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YazarSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Yazar_Id");

                    b.ToTable("tb_Yazar");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.Kitap", b =>
                {
                    b.HasOne("Hw2_EnesBayramAfşar.Models.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hw2_EnesBayramAfşar.Models.KitapDetay", "KitapDetay")
                        .WithOne("Kitap")
                        .HasForeignKey("Hw2_EnesBayramAfşar.Models.Kitap", "KitapDetayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("KitapDetay");
                });

            modelBuilder.Entity("Hw2_EnesBayramAfşar.Models.KitapDetay", b =>
                {
                    b.Navigation("Kitap");
                });
#pragma warning restore 612, 618
        }
    }
}
