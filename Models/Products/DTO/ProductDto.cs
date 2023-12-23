namespace _2dBurgerWebAPI.Models.Productos.DTO;

public class ProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }
    public required bool IsActive { get; set; }
}
