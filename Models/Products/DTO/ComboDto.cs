using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Models.Productos.DTO;

public class ComboDto : ProductDto
{
    public required string ComboCategory { get; set; }
    public virtual IEnumerable<ComboFoodDto> ComboFoods { get; set; } = null!;
}