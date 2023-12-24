using System.ComponentModel.DataAnnotations;
using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Models.Logs;
public abstract class Log<T>
{
    [Key] public int Id { get; set; }
    [Required] public DateTime Date { get; set; }
    [Required] public virtual T Value { get; set; } = default!;
    
    // Required ID's
    public int ProductId { get; set; }
    
    // Navigation entities
    public virtual Product Product { get; set; } = null!;
}
