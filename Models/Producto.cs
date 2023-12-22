using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models;

public class Producto
{
    [Key]
    public int codigo { get; set; }
    [Required]
    public int codigoNombreActual { get; set; }
    [Required]
    public int codigoDescripcionActual { get; set; }
    [Required]
    public int codigoPrecioActual { get; set; }
    [Required]
    public int codigoDescuentoActual { get; set; }

    public ComboComida[] comidas { get; set; } = null!;
    public ComboComida[] combos { get; set; } = null!;
}
