namespace _2dBurgerWebAPI.Data;

using Microsoft.EntityFrameworkCore;
using _2dBurgerWebAPI.Models;
public class ApplicationContext : DbContext
{
    DbSet<Producto> Comidas { get; set; } = null!;
    DbSet<Producto> Combos { get; set; } = null!;
    DbSet<ComidasCombo> ComidasCombo { get; set; } = null!;
    DbSet<AtributoProducto<string>> HistorialNombres { get; set; } = null!;
    DbSet<AtributoProducto<string>> HistorialDescripciones { get; set; } = null!;
    DbSet<AtributoProducto<decimal>> HistorialPrecios { get; set; } = null!;
    DbSet<AtributoProducto<decimal>> HistorialDescuentos { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //its a bad practice use the string connection like this...
        options.UseSqlServer(@"Server=ChrisLp\CHRISDBSERVER;Initial Catalog=2dBurger;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True"); 
    }

    //Run in cli
    //1) dotnet ef migrations add NameOfMigration
    //2) dotnet ef database update
}
