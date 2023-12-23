using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models.Logs;
public abstract class Log<T>
{
    [Key] public int Id { get; set; }
    [Required] public DateTime Date { get; set; }
    [Required] public virtual T Value { get; set; } = default!;
}
