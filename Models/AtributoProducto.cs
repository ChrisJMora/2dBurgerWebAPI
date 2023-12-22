using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models;

public abstract class AtributoProducto<T>
{
    [Key]
    public int codigo { get; set; }
    [Required]
    public T valor { get; set; } = default!;
    [Required]
    public DateTime fecha { get; set; }
}

public class HistorialNombres : AtributoProducto<string>{}
public class HistorialDescripciones : AtributoProducto<string>{}
public class HistorialPrecios : AtributoProducto<decimal>{}
public class HistorialDescuentos : AtributoProducto<decimal>{}
