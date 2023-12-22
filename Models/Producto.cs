using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    public HistorialNombres nombreActual { get; set; } = null!;
}
public class Combo : Producto
{ 
    public HistorialComidas comidasActuales { get; set; } = null!;
}
public class Comida : Producto { }
public class ComboComida
{
    [Key]
    [JsonIgnore]
    public int codigo { get; set; }
    [JsonIgnore]
    public int codigoHistorialComida { get; set; }
    [JsonIgnore]
    public int codigoComida { get; set; }
    [Required]
    public int cantidad { get; set; }

    public Comida comida { get; set; } = null!;
}