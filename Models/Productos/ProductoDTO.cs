namespace _2dBurgerWebAPI;

public class ProductoDTO
{
    public string nombre { get; set; } = null!;
    public string descripcion { get; set; } = null!;
    public decimal precio { get; set; }
    public decimal descuento { get; set; }
    public bool activo { get; set; }
}

public class ComboDTO : ProductoDTO
{
    public List<ComidaDTO> comidas { get; set; } = null!;
}

public class ComidaDTO : ProductoDTO {}