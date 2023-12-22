﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2dBurgerWebAPI.Data;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231222063859_CampoActivoProducto")]
    partial class CampoActivoProducto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Combo", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<int>("codigoDescripcionActual")
                        .HasColumnType("int");

                    b.Property<int>("codigoDescuentoActual")
                        .HasColumnType("int");

                    b.Property<int>("codigoNombreActual")
                        .HasColumnType("int");

                    b.Property<int>("codigoPrecioActual")
                        .HasColumnType("int");

                    b.HasKey("codigo");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.ComboComida", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("codigoCombo")
                        .HasColumnType("int");

                    b.Property<int>("codigoComida")
                        .HasColumnType("int");

                    b.HasKey("codigo");

                    b.HasIndex("codigoCombo");

                    b.HasIndex("codigoComida");

                    b.ToTable("ComboComida");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Comida", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<int>("codigoDescripcionActual")
                        .HasColumnType("int");

                    b.Property<int>("codigoDescuentoActual")
                        .HasColumnType("int");

                    b.Property<int>("codigoNombreActual")
                        .HasColumnType("int");

                    b.Property<int>("codigoPrecioActual")
                        .HasColumnType("int");

                    b.HasKey("codigo");

                    b.ToTable("Comidas");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.HistorialDescripciones", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("valor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("codigo");

                    b.ToTable("HistorialDescripciones");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.HistorialDescuentos", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("codigo");

                    b.ToTable("HistorialDescuentos");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.HistorialNombres", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("valor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("codigo");

                    b.ToTable("HistorialNombres");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.HistorialPrecios", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("codigo");

                    b.ToTable("HistorialPrecios");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.ComboComida", b =>
                {
                    b.HasOne("_2dBurgerWebAPI.Models.Combo", "combo")
                        .WithMany("comidas")
                        .HasForeignKey("codigoCombo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("_2dBurgerWebAPI.Models.Comida", "comida")
                        .WithMany("combos")
                        .HasForeignKey("codigoComida")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("combo");

                    b.Navigation("comida");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Combo", b =>
                {
                    b.Navigation("comidas");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Comida", b =>
                {
                    b.Navigation("combos");
                });
#pragma warning restore 612, 618
        }
    }
}
