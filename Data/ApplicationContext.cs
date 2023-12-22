namespace _2dBurgerWebAPI.Data;

using Microsoft.EntityFrameworkCore;

using _2dBurgerWebAPI.Models;
public class ApplicationContext : DbContext
{
    DbSet<Producto> Comidas { get; set; } = null!;
    DbSet<Producto> Combos { get; set; } = null!;
    DbSet<ComboComida> ComidasCombo { get; set; } = null!;
    DbSet<AtributoProducto<string>> HistorialNombres { get; set; } = null!;
    DbSet<AtributoProducto<string>> HistorialDescripciones { get; set; } = null!;
    DbSet<AtributoProducto<decimal>> HistorialPrecios { get; set; } = null!;
    DbSet<AtributoProducto<decimal>> HistorialDescuentos { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //its a bad practice use the string connection like this...
        options.UseSqlServer(@"Server=ChrisLp\CHRISDBSERVER;Initial Catalog=2dBurger;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            //Un combo tiene una o varias comidas
            entity.HasMany(e => e.comidas)
                .WithOne(e => e.combo)
                .HasForeignKey(e => e.codigoCombo)
                .OnDelete(DeleteBehavior.NoAction);
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

    //Run in cli
    //1) dotnet ef migrations add NameOfMigration
    //2) dotnet ef database update
    }
}
