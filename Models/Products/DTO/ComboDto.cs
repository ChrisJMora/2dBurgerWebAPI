using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Models.Productos.DTO;

public class ComboDto : ProductDto
{
    public virtual IEnumerable<ComboFoodDto> ComboFoods { get; set; } = null!;
}