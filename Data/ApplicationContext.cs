using _2dBurgerWebAPI.Models.Categories;
using _2dBurgerWebAPI.Models.Logs;
using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Data;

using Microsoft.EntityFrameworkCore;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<FoodCategory> FoodCategories { get; set; } = null!;
    public DbSet<ComboCategory> ComboCategories { get; set; } = null!;
    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<Combo> Combos { get; set; } = null!;
    public DbSet<FoodsLog> FoodsLog { get; set; } = null!;
    public DbSet<NamesLog> NamesLog { get; set; } = null!;
    public DbSet<DescriptionsLog> DescriptionsLog { get; set; } = null!;
    public DbSet<PricesLog> PricesLog { get; set; } = null!;
    public DbSet<DiscountsLog> DiscountsLog { get; set; } = null!;

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

        modelBuilder.Entity<Food>(entity =>
        {
            entity
                .HasOne(e => e.CurrentFoodCategory)
                .WithMany()
                .HasForeignKey(e => e.CurrentFoodCategoryId);
        });

        modelBuilder.Entity<Combo>(entity =>
        {
            entity
                .HasOne(e => e.CurrentComboCategory)
                .WithOne()
                .HasForeignKey<Combo>(e => e.CurrentComboCategoryId);
            entity
                .HasOne(e => e.CurrentFoods)
                .WithOne()
                .HasForeignKey<Combo>(e => e.CurrentFoodsId);
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
            entity
                .HasOne(e => e.Product)
                .WithOne()
                .HasForeignKey<FoodsLog>(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<NamesLog>(entity =>
        {
            entity.Property(e => e.Value).HasColumnType("varchar(50)");
            entity
                .HasOne(e => e.Product)
                .WithOne()
                .HasForeignKey<NamesLog>(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<DescriptionsLog>(entity =>
        {
            entity.Property(e => e.Value).HasColumnType("varchar(100)");
            entity
                .HasOne(e => e.Product)
                .WithOne()
                .HasForeignKey<DescriptionsLog>(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PricesLog>(entity =>
        {
            entity.Property(e => e.Value).HasColumnType("decimal(4,2)");
            entity
                .HasOne(e => e.Product)
                .WithOne()
                .HasForeignKey<PricesLog>(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<DiscountsLog>(entity =>
        {
            entity.Property(e => e.Value).HasColumnType("decimal(4,2)");
            entity
                .HasOne(e => e.Product)
                .WithOne()
                .HasForeignKey<DiscountsLog>(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        //Run in cli
        //1) dotnet ef migrations add NameOfMigration
        //2) dotnet ef database update
    }
}
