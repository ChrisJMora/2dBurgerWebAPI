using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Models.Logs;

public class FoodsLog : Log<IEnumerable<ComboFood>>
{
    public virtual IEnumerable<Food> Foods { get; set; } = new List<Food>();
}