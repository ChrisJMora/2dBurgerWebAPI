using _2dBurgerWebAPI.Models.Logs;
using _2dBurgerWebAPI.Models.Productos.DTO;
using _2dBurgerWebAPI.Models.Products;

namespace _2dBurgerWebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using _2dBurgerWebAPI.Data;
using _2dBurgerWebAPI.Models;
using _2dBurgerWebAPI.Models.Productos;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.ComponentModel;

[ApiController]
[Route("[controller]")]
public class ProductController(ApplicationContext context) : Controller
{
    [HttpGet("GetCombos")]
    public IEnumerable<ComboDto> GetCombos()
    {
        var combosDto = context.Combos.Select(combo => new ComboDto
        {
            Name = combo.CurrentName.Value,
            Description = combo.CurrentDescription.Value,
            Price = combo.CurrentPrice.Value,
            Discount = combo.CurrentDiscount.Value,
            IsActive = combo.IsActive,
            ComboFoods = combo.CurrentFoods.Value.Select(comboFood => new ComboFoodDto()
            {
                Name = comboFood.Food.CurrentName.Value,
                Description = comboFood.Food.CurrentDescription.Value,
                Amount = comboFood.Amount,
            })
        });
        return combosDto;
    }

    [HttpGet("GetFoods")]
    public IEnumerable<FoodDto> GetFoods()
    {
        var foodsDto = context.Foods.Select(food => new FoodDto()
        {
            Name = food.CurrentName.Value,
            Description = food.CurrentDescription.Value,
            Price = food.CurrentPrice.Value,
            Discount = food.CurrentDiscount.Value,
            IsActive = food.IsActive
        });
        return foodsDto;
    }

    [HttpPost("AddFood/{name}/{description}/{price:decimal}/{discount:decimal}")]
    public async Task AddFood(string name, string description, decimal price, decimal discount)
    {
        var food = new Food();
        food.InitFood(name, description, price, discount);
        // Add Food
        context.Foods.Add(food);
        await context.SaveChangesAsync();
    }

    [HttpPost("AddCombo/{name}/{description}/{discount:decimal}")]
    public async Task AddCombo(string name, string description, decimal discount, Dictionary<int, int> idFoods)
    {
        var combo = new Combo();
        combo.InitCombo(name, description, discount, await InitComboFoods(idFoods));
        // Add Combo
        context.Combos.Add(combo);
        await context.SaveChangesAsync();
    }
    
    // Auxiliar methods
    private async Task<List<ComboFood>> InitComboFoods(Dictionary<int, int> idFoods)
    {
        var comboFoods = new List<ComboFood>();
        foreach (var p in idFoods)
        {
            var food = await context.Foods.FindAsync(p.Key);
            if (food == null)
                throw new Exception("The food was not found");
            comboFoods.Add(new ComboFood { Food = food, Amount = p.Value });
        }

        return comboFoods;
    }
}