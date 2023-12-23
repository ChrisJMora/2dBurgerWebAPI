﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2dBurgerWebAPI.Data;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2dBurgerWebAPI.Models.HistorialComidas", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("codigo");

                    b.ToTable("HistorialComidas");
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
                        .HasColumnType("decimal");

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
                        .HasColumnType("decimal");

                    b.HasKey("codigo");

                    b.ToTable("HistorialPrecios");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.ComboComida", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("codigoComida")
                        .HasColumnType("int");

                    b.Property<int>("codigoHistorialComida")
                        .HasColumnType("int");

                    b.HasKey("codigo");

                    b.HasIndex("codigoComida");

                    b.HasIndex("codigoHistorialComida");

                    b.ToTable("ComboComida");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.Producto", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

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

                    b.HasIndex("codigoDescripcionActual")
                        .IsUnique();

                    b.HasIndex("codigoDescuentoActual")
                        .IsUnique();

                    b.HasIndex("codigoNombreActual")
                        .IsUnique();

                    b.HasIndex("codigoPrecioActual")
                        .IsUnique();

                    b.ToTable("Producto");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Producto");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.Combo", b =>
                {
                    b.HasBaseType("_2dBurgerWebAPI.Models.Productos.Producto");

                    b.Property<int>("codigoComidasActuales")
                        .HasColumnType("int");

                    b.HasIndex("codigoComidasActuales")
                        .IsUnique()
                        .HasFilter("[codigoComidasActuales] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Combo");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.Comida", b =>
                {
                    b.HasBaseType("_2dBurgerWebAPI.Models.Productos.Producto");

                    b.HasDiscriminator().HasValue("Comida");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.ComboComida", b =>
                {
                    b.HasOne("_2dBurgerWebAPI.Models.Productos.Comida", "comida")
                        .WithMany("comboComidas")
                        .HasForeignKey("codigoComida")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("_2dBurgerWebAPI.Models.HistorialComidas", "historialComida")
                        .WithMany("valor")
                        .HasForeignKey("codigoHistorialComida")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("comida");

                    b.Navigation("historialComida");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.Producto", b =>
                {
                    b.HasOne("_2dBurgerWebAPI.Models.HistorialDescripciones", "descripcionActual")
                        .WithOne()
                        .HasForeignKey("_2dBurgerWebAPI.Models.Productos.Producto", "codigoDescripcionActual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2dBurgerWebAPI.Models.HistorialDescuentos", "descuentoActual")
                        .WithOne()
                        .HasForeignKey("_2dBurgerWebAPI.Models.Productos.Producto", "codigoDescuentoActual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2dBurgerWebAPI.Models.HistorialNombres", "nombreActual")
                        .WithOne()
                        .HasForeignKey("_2dBurgerWebAPI.Models.Productos.Producto", "codigoNombreActual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2dBurgerWebAPI.Models.HistorialPrecios", "precioActual")
                        .WithOne()
                        .HasForeignKey("_2dBurgerWebAPI.Models.Productos.Producto", "codigoPrecioActual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("descripcionActual");

                    b.Navigation("descuentoActual");

                    b.Navigation("nombreActual");

                    b.Navigation("precioActual");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.Combo", b =>
                {
                    b.HasOne("_2dBurgerWebAPI.Models.HistorialComidas", "comidasActuales")
                        .WithOne()
                        .HasForeignKey("_2dBurgerWebAPI.Models.Productos.Combo", "codigoComidasActuales")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comidasActuales");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.HistorialComidas", b =>
                {
                    b.Navigation("valor");
                });

            modelBuilder.Entity("_2dBurgerWebAPI.Models.Productos.Comida", b =>
                {
                    b.Navigation("comboComidas");
                });
#pragma warning restore 612, 618
        }
    }
}
