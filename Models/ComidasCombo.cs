using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models;

public class ComidasCombo
{
    [Key]
    public int codigo { get; set; }
    [Required]
    public int codigoComida { get; set; }
    [Required]
    public int codigoCombo { get; set; }
    [Required]
    public int cantidad { get; set; }

    // public Producto comida { get; set; } = null!;
    // public Producto combo { get; set; } = null!;
}
