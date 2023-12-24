using System.ComponentModel.DataAnnotations;
using _2dBurgerWebAPI.Models.Categories;
using _2dBurgerWebAPI.Models.Logs;

namespace _2dBurgerWebAPI.Models.Products;
public class Combo : Product
{ 
    // Required ID's
    [Required] public int CurrentFoodsId { get; set; }
    [Required] public int CurrentComboCategoryId { get; set; }
    
    // Navigation entitites
    public virtual FoodsLog CurrentFoods { get; set; } = null!;
    public virtual ComboCategory CurrentComboCategory { get; set; } = null!;

    public void InitCombo(string name, string description, decimal discount,
        IEnumerable<ComboFood> comboFoods, ComboCategory comboCategory)
    {
        InitProduct(name, description, discount);
        // Init combo foods
        CurrentFoods = new FoodsLog() { Date = DateTime.Now, Value = comboFoods };
        // Init combo current price
        foreach (var comboFood in CurrentFoods.Value)
            CurrentPrice.Value += comboFood.Food.CurrentPrice.Value * comboFood.Amount;
        CurrentComboCategory = comboCategory;
    }
    
    
}