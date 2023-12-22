namespace _2dBurgerWebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using _2dBurgerWebAPI.Data;
using _2dBurgerWebAPI.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ProductoController : Controller
{
    private readonly ApplicationContext _context;

    public ProductoController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("ObtenerCombos")]
    public async Task<IEnumerable<Combo>> ObtenerCombos()
    {
        return await _context.Combos.ToListAsync();
    }

    [HttpGet("ObtenerComidas")]
    public async Task<IEnumerable<Comida>> ObtenerComidas()
    {
        return await _context.Comidas.ToListAsync();
    }

}
