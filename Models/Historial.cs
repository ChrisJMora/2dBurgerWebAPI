using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _2dBurgerWebAPI.Models;

public abstract class Historial<T>
{
    [Key]
    [JsonIgnore]
    public int codigo { get; set; }
    [Required]
    public DateTime fecha { get; set; }
    [Required]
    public T valor { get; set; } = default!;
}

public class HistorialNombres : Historial<string>
{
    [JsonIgnore]
    public int codigoProducto { get; set; }
}
public class HistorialDescripciones : Historial<string>{}
public class HistorialPrecios : Historial<decimal>{}
public class HistorialDescuentos : Historial<decimal>{}
public class HistorialComidas : Historial<List<ComboComida>>
{
    [JsonIgnore]
    public int codigoCombo { get; set; }
}
