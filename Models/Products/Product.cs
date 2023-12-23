using System.ComponentModel.DataAnnotations;
using _2dBurgerWebAPI.Models.Logs;

namespace _2dBurgerWebAPI.Models.Products;
public abstract class Product
{
    [Key] public int Id { get; set; }
    [Required] public bool IsActive { get; set; }
    
    // Required ID's
    [Required] public int CurrentNameId { get; }
    [Required] public int CurrentDescriptionId { get; }
    [Required] public int CurrentPriceId { get; }
    [Required] public int CurrentDiscountId { get; }
    
    // Navigation entities
    public virtual NamesLog CurrentName { get; set; } = null!;
    public virtual DescriptionsLog CurrentDescription { get; set; } = null!;
    public virtual PricesLog CurrentPrice { get; set; } = null!;
    public virtual DiscountsLog CurrentDiscount { get; set; } = null!;
    
    protected void InitProduct(string name, string description, decimal discount)
    {
        // Validations
        if (string.IsNullOrEmpty(name))
            throw new Exception("The name is null or empty");
        if (string.IsNullOrEmpty(description))
            throw new Exception("The description is null or empty");
        if (discount < 0 || discount > 1)
            throw new Exception("The discount must be greater than cero and less than one");
        
        // Current date and time
        var currentDate = DateTime.Now;

        CurrentName = new NamesLog() { Date = currentDate, Value = name };
        CurrentDescription = new DescriptionsLog() { Date = currentDate, Value = description };
        CurrentDiscount = new DiscountsLog() { Date = currentDate, Value = discount };
        CurrentPrice = new PricesLog() { Date = currentDate, Value = 0.00m };
        IsActive = true;
    }
    
}