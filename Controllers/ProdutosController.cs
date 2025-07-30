using Microsoft.AspNetCore.Mvc;
using ControleEstoqueApi.Models;
using ControleEstoqueApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Ok(produtos);   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoPorID(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] Produto novoProduto)
        {
            _context.Produtos.Add(novoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutoPorID), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPost("lote")]
        public async Task<ActionResult> CriarVarios([FromBody] List<Produto> novosProdutos)
        {
            _context.Produtos.AddRange(novosProdutos);
            await _context.SaveChangesAsync();

            return Ok(novosProdutos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Produto produtoAtualizado)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Quantidade = produtoAtualizado.Quantidade;
            produto.Descricao = produtoAtualizado.Descricao;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
