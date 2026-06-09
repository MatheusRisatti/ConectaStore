using ConectaStore.API.Data;
using ConectaStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConectaStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Produtos
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetProdutos()
    {
        var produtos = _context.Produtos
            .Include(p => p.Categoria)
            .ToList();
        return Ok(produtos);
    }

    // GET: api/Produtos/5
    [HttpGet("{id}")]
    public ActionResult<Produto> GetProduto(int id)
    {
        var produto = _context.Produtos
            .Where(p => p.Id == id)
            .Include(p => p.Categoria)
            .SingleOrDefault();
        
        if (produto == null) return NotFound("Produto não existe!");

        return Ok(produto);
    }

    // GET: api/Produtos/categoria/1
    [HttpGet("categoria/{categoriaId}")]
    public ActionResult<IEnumerable<Produto>> GetProdutosCategoria(int categoriaId)
    {
        var produtos = _context.Produtos
            .Where(p => p.CategoriaId == categoriaId)
            .Include(p => p.Categoria)
            .ToList();
        return Ok(produtos);
    }

    // GET: api/Produtos/destaques
    [HttpGet("destaques")]
    public ActionResult<IEnumerable<Produto>> GetProdutosDestaque()
    {
        var produtos = _context.Produtos
            .Where(p => p.Destaque)
            .Include(p => p.Categoria)
            .ToList();
        return Ok(produtos);
    }

    // POST: api/Produtos
    [HttpPost]
    public ActionResult<Produto> PostProduto([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Confira os dados enviados");
        
        if (!_context.Categorias.Any(c => c.Id == produto.CategoriaId))
            return BadRequest("A categoria informada não existe!");
        
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        
        return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
    }

    // PUT: api/Produtos/5
    [HttpPut("{id}")]
    public ActionResult PutProduto(int id, [FromBody] Produto produto)
    {
        if (!ModelState.IsValid || id != produto.Id)
            return BadRequest("Confira os dados enviados");
        
        var oldProduto = _context.Produtos.Find(id);
        if (oldProduto == null)
            return NotFound("O produto não existe!");

        if(!CategoriaExiste(produto.CategoriaId))
            return BadRequest("Categoria não localizada");

        oldProduto.Nome = produto.Nome;
        if(produto.Descricao != null) oldProduto.Descricao = produto.Descricao;
        oldProduto.Qtde = produto.Qtde;
        oldProduto.ValorCusto = produto.ValorCusto;
        oldProduto.ValorVenda = produto.ValorVenda;
        oldProduto.Destaque = produto.Destaque;
        oldProduto.CategoriaId = produto.CategoriaId;
        if(produto.Foto != null) oldProduto.Foto = produto.Foto;
        
        _context.Entry(oldProduto).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    private bool CategoriaExiste(int id)
    {
        return _context.Categorias.Any(c => c.Id == id);
    }

    // DELETE: api/Produtos/5
    [HttpDelete("{id}")]
    public ActionResult DeleteProduto(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
            return NotFound("O produto não existe!");

        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        
        return NoContent();
    }
}