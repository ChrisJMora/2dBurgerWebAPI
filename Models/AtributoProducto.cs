using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models;

public class AtributoProducto<T>
{
    [Key]
    public int codigo { get; set; }
    [Required]
    public T valor { get; set; } = default!;
    [Required]
    public DateTime fecha { get; set; }
}
