using System.ComponentModel.DataAnnotations;

namespace _2dBurgerWebAPI.Models.Categories;

public abstract class Category
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
}