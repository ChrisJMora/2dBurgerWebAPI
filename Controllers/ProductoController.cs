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

    [HttpPost("AgregarComida/{nombre}/{descripcion}/{precio}/{decuento}")]
    public async Task AgregarComida(string nombre, string descripcion, double precio, double decuento)
    {
        Comida comida = new Comida();
        comida.InicializarProducto(nombre, descripcion, (decimal)precio, (decimal)decuento);
        _context.Comidas.Add(comida);
        await _context.SaveChangesAsync();
    }
}
