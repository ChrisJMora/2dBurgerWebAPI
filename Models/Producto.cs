using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _2dBurgerWebAPI.Models;
public abstract class Producto
{
    [Key]
    public int codigo { get; set; }
    
    [Required]
    [JsonIgnore]
    public int codigoNombreActual { get; set; }
    [Required]
    [JsonIgnore]
    public int codigoDescripcionActual { get; set; }
    [Required]
    [JsonIgnore]
    public int codigoPrecioActual { get; set; }
    [Required]
    [JsonIgnore]
    public int codigoDescuentoActual { get; set; }

    public HistorialNombres nombreActual { get; set; } = null!;
    public HistorialDescripciones descripcionActual { get; set; } = null!;
    public HistorialPrecios precioActual { get; set; } = null!;
    public HistorialDescuentos descuentoActual { get; set; } = null!;
    [Required]
    public bool activo { get; set; } = true;
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