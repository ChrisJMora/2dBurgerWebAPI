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
    public bool activo { get; set; }

    public void InicializarProducto(string nombre, string descripcion, decimal precio, decimal descuento)
    {
        DateTime fechaActual = DateTime.Now;
        nombreActual = new HistorialNombres { fecha = fechaActual, valor = nombre };
        descripcionActual = new HistorialDescripciones { fecha = fechaActual, valor = descripcion };
        precioActual = new HistorialPrecios { fecha = fechaActual, valor = precio };
        descuentoActual = new HistorialDescuentos { fecha = fechaActual, valor = descuento };
        activo = true;
    }
}
public class Combo : Producto
{ 
    public HistorialComidas comidasActuales { get; set; } = null!;
}
public class Comida : Producto {}
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