using _2dBurgerWebAPI.Models.Logs;
using _2dBurgerWebAPI.Models.Productos;

namespace _2dBurgerWebAPI.Models.Products;

public class Food : Product 
{
    // Navigation entitites
    public virtual IEnumerable<FoodsLog> FoodLog { get; } = new List<FoodsLog>();
    public virtual IEnumerable<ComboFood> ComboFoods { get; } = new List<ComboFood>();
    
    public void InitFood(string name, string description, decimal price, decimal discount)
    {
        // Validations
        if (price < 0)
            throw new Exception("The price must be greater than cero");
        
        InitProduct(name, description, discount);
        CurrentPrice = new PricesLog() { Date = DateTime.Now, Value = price };
    }
}