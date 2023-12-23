using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _2dBurgerWebAPI.Models.Productos;

public class ComboComida
{
    [Key]
    public int codigo { get; set; }
    public int cantidad { get; set; }


    public int codigoHistorialComida { get; set; }
    public int codigoComida { get; set; }
    public virtual HistorialComidas historialComida { get; set; } = null!;
    public virtual Comida comida { get; set; } = null!;
}
