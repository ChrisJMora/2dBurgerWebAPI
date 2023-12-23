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
    public async Task AgregarCombo(string nombre, string descripcion, decimal descuento, Dictionary<int, int> codigosComidas)
    {
        Combo combo = new Combo();
        List<ComboComida> comboComidas = await InicializarComidasCombo(codigosComidas);
        combo.comidasActuales = new HistorialComidas { fecha = DateTime.Now, valor = comboComidas };
        combo.InicializarCombo(nombre, descripcion, descuento);
        _context.Combos.Add(combo);
        await _context.SaveChangesAsync();
    }
    private async Task<List<ComboComida>> InicializarComidasCombo(Dictionary<int, int> codigosComidas)
    {
        List<ComboComida> comboComidas = new List<ComboComida>();
        foreach (KeyValuePair<int, int> codigoComida in codigosComidas)
        {
            Comida? comida = await _context.Comidas.FindAsync(codigoComida.Key);
            if (comida == null)
                throw new Exception("No se encontró la comida");
            ComboComida comboComida = new ComboComida { comida = comida, cantidad = codigoComida.Value };
            comboComidas.Add(comboComida);
        }
        return comboComidas;
    }
}
