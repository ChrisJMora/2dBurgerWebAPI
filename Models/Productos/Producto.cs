using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models.Productos;
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

    public virtual HistorialNombres nombreActual { get; set; } = null!;
    public virtual HistorialDescripciones descripcionActual { get; set; } = null!;
    public virtual HistorialPrecios precioActual { get; set; } = null!;
    public virtual HistorialDescuentos descuentoActual { get; set; } = null!;

    public void InicializarProducto(string nombre, string descripcion, decimal descuento)
    {
        DateTime fechaActual = DateTime.Now;
        nombreActual = new HistorialNombres { fecha = fechaActual, valor = nombre };
        descripcionActual = new HistorialDescripciones { fecha = fechaActual, valor = descripcion };
        descuentoActual = new HistorialDescuentos { fecha = fechaActual, valor = descuento };
        activo = true;
    }
}
public class Combo : Producto
{ 
    public int codigoComidasActuales { get; set; }
    public virtual HistorialComidas comidasActuales { get; set; } = null!;

    public void InicializarCombo(string nombre, string descripcion, decimal descuento)
    {
        InicializarProducto(nombre, descripcion, descuento);
        InicializarPrecioCombo();
    }
    private void InicializarPrecioCombo()
    {
        decimal precioTotal = 0;
        foreach (ComboComida comboComida in comidasActuales.valor)
        {
            precioTotal += comboComida.comida.precioActual.valor * comboComida.cantidad;
        }
        precioActual = new HistorialPrecios { fecha = DateTime.Now, valor = precioTotal };
    }
}
public class Comida : Producto 
{
    public virtual List<HistorialComidas> historialComidas { get; set; } = new();
    public virtual List<ComboComida> comboComidas { get; set; } = new();
    public void InicializarComida(string nombre, string descripcion, decimal precio, decimal descuento)
    {
        InicializarProducto(nombre, descripcion, descuento);
        precioActual = new HistorialPrecios { fecha = DateTime.Now, valor = precio };
    }
}