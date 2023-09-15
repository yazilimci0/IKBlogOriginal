﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(IKBlokContex))]
    [Migration("20230915090549_BlogYeni2")]
    partial class BlogYeni2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFLayer.Class.Gonderiler", b =>
                {
                    b.Property<int>("GonderiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GonderiId"));

                    b.Property<string>("GonderiName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("kategoriId")
                        .HasColumnType("int");

                    b.HasKey("GonderiId");

                    b.HasIndex("kategoriId");

                    b.ToTable("Gonderiler", (string)null);
                });

            modelBuilder.Entity("EFLayer.Class.Hakkimda", b =>
                {
                    b.Property<int>("hakkimdaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hakkimdaId"));

                    b.Property<string>("baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resimLinki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hakkimdaId");

                    b.ToTable("Hakkimda", (string)null);
                });

            modelBuilder.Entity("EFLayer.Class.Iletisim", b =>
                {
                    b.Property<int>("IletisimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IletisimId"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IletisimId");

                    b.ToTable("Iletisim", (string)null);
                });

            modelBuilder.Entity("EFLayer.Class.Kategories", b =>
                {
                    b.Property<int>("kategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kategoriId"));

                    b.Property<string>("kategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kategoriId");

                    b.ToTable("Kategories", (string)null);
                });

            modelBuilder.Entity("EFLayer.Class.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("EFLayer.Class.Gonderiler", b =>
                {
                    b.HasOne("EFLayer.Class.Kategories", "Kategories")
                        .WithMany("Gonderiler")
                        .HasForeignKey("kategoriId");

                    b.Navigation("Kategories");
                });

            modelBuilder.Entity("EFLayer.Class.Kategories", b =>
                {
                    b.Navigation("Gonderiler");
                });
#pragma warning restore 612, 618
        }
    }
}
