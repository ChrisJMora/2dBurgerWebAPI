namespace _2dBurgerWebAPI.Data;

using Microsoft.EntityFrameworkCore;

using _2dBurgerWebAPI.Models;
public class ApplicationContext : DbContext
{
    DbSet<Comida> Comidas { get; set; } = null!;
    DbSet<Combo> Combos { get; set; } = null!;
    DbSet<ComboComida> ComboComida { get; set; } = null!;
    DbSet<HistorialNombres> HistorialNombres { get; set; } = null!;
    DbSet<HistorialDescripciones> HistorialDescripciones { get; set; } = null!;
    DbSet<HistorialPrecios> HistorialPrecios { get; set; } = null!;
    DbSet<HistorialDescuentos> HistorialDescuentos { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //its a bad practice use the string connection like this...
        options.UseSqlServer(@"Server=ChrisLp\CHRISDBSERVER;Initial Catalog=2dBurger;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Combo>(entity =>
        {
            //Un combo tiene una o varias comidas
            entity.HasMany(e => e.comidas)
                .WithOne(e => e.combo)
                .HasForeignKey(e => e.codigoCombo)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Comida>(entity =>
        {
            //Una comida puede pertenecer a uno o varios combos
            entity.HasMany(e => e.combos)
                .WithOne(e => e.comida)
                .HasForeignKey(e => e.codigoComida)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ComboComida>(entity =>
        {
            entity.HasIndex(e => e.codigoCombo).IsUnique(false);
            entity.HasIndex(e => e.codigoComida).IsUnique(false);
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
            entity.Property(e => e.valor).HasColumnType("decimal(3,2)");
        });

        modelBuilder.Entity<HistorialDescuentos>(entity =>
        {
            entity.Property(e => e.valor).HasColumnType("decimal(3,2)");
        });

    //Run in cli
    //1) dotnet ef migrations add NameOfMigration
    //2) dotnet ef database update
    }
}
