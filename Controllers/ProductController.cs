using _2dBurgerWebAPI.Models.Categories;
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
    [HttpGet("GetFoodCategories")]
    public async Task<IEnumerable<FoodCategory>> GetFoodCategories()
    {
        return await context.FoodCategories.ToListAsync();
    }
    
    [HttpPost("AddFoodCategory/{name}")]
    public async Task AddFoodCategory(string name)
    {
        await context.FoodCategories.AddAsync(new FoodCategory() { Name = name });
        await context.SaveChangesAsync();
    }

    [HttpGet("GetComboCategories")]
    public async Task<IEnumerable<ComboCategory>> GetComboCategories()
    {
        return await context.ComboCategories.ToListAsync();
    }
    
    [HttpPost("AddComboCategory/{name}")]
    public async Task AddComboCategory(string name)
    {
        await context.ComboCategories.AddAsync(new ComboCategory() { Name = name });
        await context.SaveChangesAsync();
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
            IsActive = food.IsActive,
            FoodCategory = food.CurrentFoodCategory.Name
        });
        return foodsDto;
    }

    [HttpPost("AddFood/{name}/{description}/{price:decimal}/{discount:decimal}/{foodCategoryId:int}")]
    public async Task AddFood(string name, string description, decimal price, decimal discount, int foodCategoryId)
    {
        var food = new Food();
        var foodCategory = await context.FoodCategories.FindAsync(foodCategoryId);
        if (foodCategory == null)
            throw new Exception($"The food category with the id: {foodCategory} was not found");
        food.InitFood(name, description, price, discount, foodCategory);
        // Add Food
        context.Foods.Add(food);
        await context.SaveChangesAsync();
    }
    
    [HttpGet("GetCombos")]
    public async Task<IEnumerable<ComboDto>> GetCombos()
    {
        IEnumerable<Combo> combos = await context.Combos
            .Include(product => product.CurrentName)
            .Include(product => product.CurrentDescription)
            .Include(product => product.CurrentPrice)
            .Include(product => product.CurrentDiscount)
            .Include(combo => combo.CurrentComboCategory)
            .Include(combo => combo.CurrentFoods).ToListAsync();
        
        var combosDto = combos.Select(combo => new ComboDto
        {
            Name = combo.CurrentName.Value,
            Description = combo.CurrentDescription.Value,
            Price = combo.CurrentPrice.Value,
            Discount = combo.CurrentDiscount.Value,
            IsActive = combo.IsActive,
            ComboCategory = combo.CurrentComboCategory.Name,
            ComboFoods = combo.CurrentFoods.Value.Select(comboFood => new ComboFoodDto()
            {
                Name = comboFood.Food.CurrentName.Value,
                Description = comboFood.Food.CurrentDescription.Value,
                Amount = comboFood.Amount,
            })
        });
        return combosDto;
    }
    
    [HttpPost("AddCombo/{name}/{description}/{discount:decimal}/{comboCategoryId:int}")]
    public async Task AddCombo(string name, string description, decimal discount,
        Dictionary<int, int> idFoods, int comboCategoryId )
    {
        var combo = new Combo();
        var comboCategory = await context.ComboCategories.FindAsync(comboCategoryId);
        if (comboCategory == null)
            throw new Exception($"The combo category with the id: {comboCategoryId} was not found");
        combo.InitCombo(name, description, discount, await InitComboFoods(idFoods), comboCategory);
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
                throw new Exception($"The food with the id: {p.Key} was not found");
            comboFoods.Add(new ComboFood { Food = food, Amount = p.Value });
        }

        return comboFoods;
    }
}