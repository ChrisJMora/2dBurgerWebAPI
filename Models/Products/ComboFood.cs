using System.ComponentModel.DataAnnotations;
using _2dBurgerWebAPI.Models.Logs;

namespace _2dBurgerWebAPI.Models.Products;
public class ComboFood
{
    [Key]
    public int Id { get; set; }
    [Required] public int Amount { get; set; }
    
    // Required ID's
    public int FoodLogId { get; set; }
    public int FoodId { get; set; }
    
    // Navigation entities
    public virtual FoodsLog FoodLog { get; set; } = null!;
    public virtual Food Food { get; set; } = null!;
}