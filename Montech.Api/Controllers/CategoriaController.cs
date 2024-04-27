using Microsoft.AspNetCore.Mvc;
using Montech.Api.Data;
using Montech.Api.Models;

namespace Montech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult PostCategoria([FromBody] Categoria categoria)
    {
        _context.Categoria.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCategoriaPorId),
                               new { id = categoria.Id },
                               categoria);  //retorna um 201 com location no header
    }

    [HttpGet]
    public IEnumerable<Categoria> GetAllCategorias([FromQuery] int skip = 0,
        [FromQuery] int take = 25) //rota => ?skip={value}&take={value}
    {
        return _context.Categoria.Skip(skip).Take(take);
    }

    [HttpGet("{id}")] //IActionResult para retornar ação que foi executada --> 'NotFound && OK'
    public IActionResult GetCategoriaPorId(int id)
    {
        var categoria = _context.Categoria.FirstOrDefault(c => c.Id == id);

        if (categoria == null) return NotFound();
        return Ok(categoria);
    }

    [HttpPut("{id}")]
    public IActionResult PutCategoria(int id, [FromBody] Categoria categoria)
    {
        var categoriaExistente = _context.Categoria.FirstOrDefault(c => c.Id == id);

        if (categoriaExistente == null) return NotFound();
        
        categoriaExistente.Nome = categoria.Nome;
        categoriaExistente.IsValid = categoria.IsValid;
        _context.SaveChanges();

        return NoContent(); // Retorna um status 204 No Content indicando que a atualização foi bem-sucedida
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategoria(int id)
    {
        var categoria = _context.Categoria.FirstOrDefault(c => c.Id == id);

        if (categoria == null) return NotFound();

        _context.Categoria.Remove(categoria);
        _context.SaveChanges();

        return NoContent(); // Retorna um status 204 No Content indicando que a remoção foi bem-sucedida
    }
}
