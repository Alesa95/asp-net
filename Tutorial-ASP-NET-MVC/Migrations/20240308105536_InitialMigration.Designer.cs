﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tutorial_ASP_NET_MVC.Data;

#nullable disable

namespace Tutorial_ASP_NET_MVC.Migrations
{
    [DbContext(typeof(Tutorial_ASP_NET_MVCContext))]
    [Migration("20240308105536_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tutorial_ASP_NET_MVC.Models.Consola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("PrecioBruto")
                        .HasColumnType("real");

                    b.Property<int>("TipoIva")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Consola");
                });

            modelBuilder.Entity("Tutorial_ASP_NET_MVC.Models.Videojuego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConsolaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Pegi")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ConsolaId");

                    b.ToTable("Videojuego");
                });

            modelBuilder.Entity("Tutorial_ASP_NET_MVC.Models.Videojuego", b =>
                {
                    b.HasOne("Tutorial_ASP_NET_MVC.Models.Consola", "Consola")
                        .WithMany("Videojuegos")
                        .HasForeignKey("ConsolaId");

                    b.Navigation("Consola");
                });

            modelBuilder.Entity("Tutorial_ASP_NET_MVC.Models.Consola", b =>
                {
                    b.Navigation("Videojuegos");
                });
#pragma warning restore 612, 618
        }
    }
}