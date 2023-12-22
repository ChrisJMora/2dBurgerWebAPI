using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models;

public class ComboComida
{
    [Key]
    public int codigo { get; set; }
    [Required]
    public int codigoComida { get; set; }
    [Required]
    public int codigoCombo { get; set; }
    [Required]
    public int cantidad { get; set; }

    public Comida comida { get; set; } = null!;
    public Combo combo { get; set; } = null!;
}
