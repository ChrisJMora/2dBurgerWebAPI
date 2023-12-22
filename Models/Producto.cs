using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI;

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
}
