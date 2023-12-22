namespace _2dBurgerWebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using _2dBurgerWebAPI.Data;
using _2dBurgerWebAPI.Models;
using _2dBurgerWebAPI.Models.Productos;
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
    public IEnumerable<ComidaDTO> ObtenerComidas()
    {
        var comidasDTO = from comida in _context.Comidas
                         select new ComidaDTO
                         {
                             nombre = comida.nombreActual.valor,
                             descripcion = comida.descripcionActual.valor,
                             precio = comida.precioActual.valor,
                             descuento = comida.descuentoActual.valor,
                             activo = comida.activo
                         };
        return comidasDTO;
    }

    [HttpPost("AgregarComida/{nombre}/{descripcion}/{precio}/{descuento}")]
    public async Task AgregarComida(string nombre, string descripcion, decimal precio, decimal descuento)
    {
        
        Comida comida = new Comida();
        comida.InicializarComida(nombre, descripcion, precio, descuento);
        _context.Comidas.Add(comida);
        await _context.SaveChangesAsync();
    }

    [HttpPost("AgregarCombo/{nombre}/{descripcion}/{descuento}")]
    public async Task AgregarCombo(string nombre, string descripcion, decimal descuento, int[] codigosComidas)
    {
        Combo combo = new Combo();
        combo.InicializarCombo(nombre, descripcion, descuento);
        List<ComboComida> comboComidas = await InicializarComidas(codigosComidas);
        combo.comidasActuales = new HistorialComidas { fecha = DateTime.Now, valor = comboComidas };
        _context.Combos.Add(combo);
        await _context.SaveChangesAsync();
    }


    private async Task<List<ComboComida>> InicializarComidas(int[] codigosComidas)
    {
        List<ComboComida> comboComidas = new List<ComboComida>();
        List<Comida> comidas = await BuscarComidas(codigosComidas);
        foreach (Comida comida in comidas)
        {
            comboComidas.Add(new ComboComida { comida = comida });
        }
        return comboComidas;
    }

    private async Task<List<Comida>> BuscarComidas(int[] codigosComidas)
    {
        List<Comida> comidas = new List<Comida>();
        foreach (int codigo in codigosComidas)
        {
            Comida? comida = await _context.Comidas.FindAsync(codigo);
            if (comida == null)
            {
                throw new Exception("No se encontro la comida con el codigo: " + codigo);
            }
            comidas.Add(comida);
        }
        return comidas;
    }

}
