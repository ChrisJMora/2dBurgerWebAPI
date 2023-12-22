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
    public bool activo { get; set; } = true;
}

public class Combo : Producto
{
    public List<ComboComida> comidas { get; } = new();
}
public class Comida : Producto 
{
    // public List<Combo> combos { get; } = new();
    // public List<ComboComida> comboComidas { get; } = new();
    // public ComboComida[] combos { get; set; } = null!;
}