using _2dBurgerWebAPI.Models.Logs;
using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Data;

using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<Combo> Combos { get; set; } = null!;
    public DbSet<FoodsLog> FoodsLog { get; set; } = null!;
    public DbSet<NamesLog> NamesLog { get; set; } = null!;
    public DbSet<DescriptionsLog> DescriptionsLog { get; set; } = null!;
    public DbSet<PricesLog> PricesLog { get; set; } = null!;
    public DbSet<DiscountsLog> DiscountsLog { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // its a bad practice use the string connection like this...
    //  options.UseSqlServer(@"Server=ChrisLp\CHRISDBSERVER;Initial Catalog=2dBurger;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True"); 
        optionsBuilder.EnableSensitiveDataLogging(); // Enable sensitive data logging
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity => {
            entity
                .HasOne(e => e.CurrentName)
                .WithOne()
                .HasForeignKey<Product>(e => e.CurrentNameId);
            entity
                .HasOne(e => e.CurrentDescription)
                .WithOne()
                .HasForeignKey<Product> (e => e.CurrentDescriptionId);
            entity
                .HasOne(e => e.CurrentPrice)
                .WithOne()
                .HasForeignKey<Product>(e => e.CurrentPriceId);
            entity
                .HasOne(e => e.CurrentDiscount)
                .WithOne()
                .HasForeignKey<Product>(e => e.CurrentDiscountId);
        });

        modelBuilder.Entity<Combo>(entity =>
<<<<<<< HEAD
        {
            entity
                .HasOne(e => e.CurrentFoods)
                .WithOne()
                .HasForeignKey<Combo>(e => e.CurrentFoodsId);
=======
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
>>>>>>> 27a8466e7adfef703006018fb0e31dfdd6dabc3a
        });

        modelBuilder.Entity<FoodsLog>(entity =>
        {
            entity
                .HasMany(e => e.Foods)
                .WithMany(e => e.FoodLog)
                .UsingEntity<ComboFood>(
                    r => r
                        .HasOne(e => e.Food)
                        .WithMany(e => e.ComboFoods)
                        .HasForeignKey(e => e.FoodId)
                        .OnDelete(DeleteBehavior.NoAction),
                    l => l
                        .HasOne(e => e.FoodLog)
                        .WithMany(e => e.Value)
                        .HasForeignKey(e => e.FoodLogId)
                        .OnDelete(DeleteBehavior.NoAction)
                );
        });

        modelBuilder.Entity<NamesLog>(entity =>
        {
            entity.Property(e => e.Value).HasColumnType("varchar(50)");
        });

        modelBuilder.Entity<DescriptionsLog>(entity =>
        {
<<<<<<< HEAD
            entity.Property(e => e.Value).HasColumnType("varchar(100)");
=======
            entity.Property(e => e.valor).HasColumnType("decimal");
>>>>>>> 27a8466e7adfef703006018fb0e31dfdd6dabc3a
        });

        modelBuilder.Entity<PricesLog>(entity =>
        {
<<<<<<< HEAD
            entity.Property(e => e.Value).HasColumnType("decimal");
        });

        modelBuilder.Entity<DiscountsLog>(entity =>
        {
            entity.Property(e => e.Value).HasColumnType("decimal");
=======
            entity.Property(e => e.valor).HasColumnType("decimal");
>>>>>>> 27a8466e7adfef703006018fb0e31dfdd6dabc3a
        });

    //Run in cli
    //1) dotnet ef migrations add NameOfMigration
    //2) dotnet ef database update
    }
}
