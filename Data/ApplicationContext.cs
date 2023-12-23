﻿namespace _2dBurgerWebAPI.Data;

using Microsoft.EntityFrameworkCore;

using _2dBurgerWebAPI.Models;
using _2dBurgerWebAPI.Models.Productos;
public class ApplicationContext : DbContext
{
    public DbSet<Comida> Comidas { get; set; } = null!;
    public DbSet<Combo> Combos { get; set; } = null!;
    public DbSet<HistorialComidas> HistorialComidas { get; set; } = null!;
    public DbSet<HistorialNombres> HistorialNombres { get; set; } = null!;
    public DbSet<HistorialDescripciones> HistorialDescripciones { get; set; } = null!;
    public DbSet<HistorialPrecios> HistorialPrecios { get; set; } = null!;
    public DbSet<HistorialDescuentos> HistorialDescuentos { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // its a bad practice use the string connection like this...
    //  options.UseSqlServer(@"Server=ChrisLp\CHRISDBSERVER;Initial Catalog=2dBurger;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True"); 
        optionsBuilder.EnableSensitiveDataLogging(); // Enable sensitive data logging
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity => {
            entity
                .HasOne(e => e.nombreActual)
                .WithOne()
                .HasForeignKey<Producto>(e => e.codigoNombreActual);
            entity
                .HasOne(e => e.descripcionActual)
                .WithOne()
                .HasForeignKey<Producto> (e => e.codigoDescripcionActual);
            entity
                .HasOne(e => e.precioActual)
                .WithOne()
                .HasForeignKey<Producto>(e => e.codigoPrecioActual);
            entity
                .HasOne(e => e.descuentoActual)
                .WithOne()
                .HasForeignKey<Producto>(e => e.codigoDescuentoActual);
        });

        modelBuilder.Entity<Combo>(entity =>
        {
            entity
                .HasOne(e => e.comidasActuales)
                .WithOne()
                .HasForeignKey<Combo>(e => e.codigoComidasActuales);
        });

        modelBuilder.Entity<HistorialComidas>(entity =>
        {
            entity
                .HasMany(e => e.Comidas)
                .WithMany(e => e.historialComidas)
                .UsingEntity<ComboComida>(
                    r => r
                        .HasOne(e => e.comida)
                        .WithMany(e => e.comboComidas)
                        .HasForeignKey(e => e.codigoComida)
                        .OnDelete(DeleteBehavior.NoAction),
                    l => l
                        .HasOne(e => e.historialComida)
                        .WithMany(e => e.valor)
                        .HasForeignKey(e => e.codigoHistorialComida)
                        .OnDelete(DeleteBehavior.NoAction)
                );
        });

        modelBuilder.Entity<HistorialNombres>(entity =>
        {
            entity.Property(e => e.valor).HasColumnType("varchar(50)");
        });

        modelBuilder.Entity<HistorialDescripciones>(entity =>
        {
            entity.Property(e => e.valor).HasColumnType("varchar(100)");
        });

        modelBuilder.Entity<HistorialPrecios>(entity =>
        {
            entity.Property(e => e.valor).HasColumnType("decimal");
        });

        modelBuilder.Entity<HistorialDescuentos>(entity =>
        {
            entity.Property(e => e.valor).HasColumnType("decimal");
        });

    //Run in cli
    //1) dotnet ef migrations add NameOfMigration
    //2) dotnet ef database update
    }
}
