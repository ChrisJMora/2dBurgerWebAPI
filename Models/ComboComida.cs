using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _2dBurgerWebAPI.Models;

public class ComboComida
{
    [Key]
    [JsonIgnore]
    public int codigo { get; set; }
    [JsonIgnore]
    public int codigoCombo { get; set; }
    [JsonIgnore]
    public int codigoComida { get; set; }
    [Required]
    public int cantidad { get; set; }

    public Comida comida { get; set; } = null!;
    // public Combo combo { get; set; } = null!;
}
