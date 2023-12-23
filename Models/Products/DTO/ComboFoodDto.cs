using System.ComponentModel.DataAnnotations;
using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Models.Productos.DTO;

public class ComboFoodDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Amount { get; set; }
}