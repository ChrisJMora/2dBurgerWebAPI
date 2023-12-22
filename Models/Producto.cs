using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models;

public abstract class Producto
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
    [Required]
    public bool activo { get; set; }
}

public class Combo : Producto
{
    public ComboComida[] comidas { get; set; } = null!;
}
public class Comida : Producto 
{
    public ComboComida[] combos { get; set; } = null!;
}