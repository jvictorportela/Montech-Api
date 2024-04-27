using Microsoft.AspNetCore.Mvc;
using Montech.Api.Data;
using Montech.Api.Models;

namespace Montech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult PostProduto([FromBody] Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProdutoPorId),
                               new { id = produto.Id },
                               produto);  //retorna um 201 com location no header
    }

    [HttpGet]
    public IEnumerable<Produto> GetAllProdutos([FromQuery] int skip = 0,
        [FromQuery] int take = 25) //rota => ?skip={value}&take={value}
    {
        return _context.Produtos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")] //IActionResult para retornar ação que foi executada --> 'NotFound && OK'
    public IActionResult GetProdutoPorId(Guid id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPut("{id}")]
    public IActionResult PutProduto(Guid id, [FromBody] Produto produto)
    {
        var produtoExistente = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produtoExistente == null) return NotFound();

        produtoExistente.Nome = produto.Nome;
        produtoExistente.ValorMercado = produto.ValorMercado;
        produtoExistente.ValorCompra = produto.ValorCompra;
        produtoExistente.IsValid = produto.IsValid;
        produtoExistente.CategoriaId = produto.CategoriaId;
        produtoExistente.Descricao = produto.Descricao;
        produtoExistente.DataCompra = produto.DataCompra;
        _context.SaveChanges();

        return NoContent(); // Retorna um status 204 No Content indicando que a atualização foi bem-sucedida
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduto(Guid id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null) return NotFound();

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return NoContent(); // Retorna um status 204 No Content indicando que a remoção foi bem-sucedida
    }
}
