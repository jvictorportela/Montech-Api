using Microsoft.AspNetCore.Mvc;
using Montech.Api.Data;
using Montech.Api.Models;

namespace Montech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    private AppDbContext _context;

    public EmpresaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult PostEmpresa([FromBody] Empresa empresa)
    {
        _context.Empresa.Add(empresa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEmpresaPorId),
                               new { id = empresa.Id },
                               empresa);  //retorna um 201 com location no header
    }

    [HttpGet]
    public IEnumerable<Empresa> GetAllEmpresas([FromQuery] int skip = 0,
       [FromQuery] int take = 25) //rota => ?skip={value}&take={value}
    {
        return _context.Empresa.Skip(skip).Take(take);
    }

    [HttpGet("{id}")] //IActionResult para retornar ação que foi executada --> 'NotFound && OK'
    public IActionResult GetEmpresaPorId(Guid id)
    {
        var empresa = _context.Empresa.FirstOrDefault(e => e.Id == id);

        if (empresa == null) return NotFound();
        return Ok(empresa);
    }

    [HttpPut("{id}")]
    public IActionResult PutEmpresa(Guid id, [FromBody] Empresa empresa)
    {
        var empresaExistente = _context.Empresa.FirstOrDefault(e => e.Id == id);

        if (empresaExistente == null) return NotFound();

        empresaExistente.Nome = empresa.Nome;
        empresaExistente.IsValid = empresa.IsValid;
        _context.SaveChanges();

        return NoContent(); // Retorna um status 204 No Content indicando que a atualização foi bem-sucedida
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmpresa(Guid id)
    {
        var empresa = _context.Empresa.FirstOrDefault(e => e.Id == id);

        if (empresa == null) return NotFound();

        _context.Empresa.Remove(empresa);
        _context.SaveChanges();

        return NoContent(); // Retorna um status 204 No Content indicando que a remoção foi bem-sucedida
    }
}
