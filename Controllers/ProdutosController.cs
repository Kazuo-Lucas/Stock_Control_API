using Microsoft.AspNetCore.Mvc;
using ControleEstoqueApi.Models;

namespace MeuProjeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>();

        [HttpGet]
        public ActionResult<List<Produto>> GetProductos()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProdutoPorID(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Criar([FromBody] Produto novoProduto)
        {
            produtos.Add(novoProduto);
            return CreatedAtAction(nameof(GetProdutoPorID), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPost]
        public ActionResult CriarVarios([FromBody] List<Produto> novosProdutos)
        {
            produtos.AddRange(novosProdutos);
            return Ok(novosProdutos);
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Produto produtoAtualizado)
        {
            var index = produtos.FindIndex(p => p.Id == id);
            if (index == -1)
                return NotFound();

            produtoAtualizado.Id = id;
            produtos[index] = produtoAtualizado;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produtos.Remove(produto);
            return NoContent();
        }
    }
}
