using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace APIProdutosAula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<List<Produtos>> GetProdutos() =>
            await _produtoService.GetAsync();

        [HttpPost]
        public async Task<Produtos> PostProdutos(Produtos produtos)
        {
            await _produtoService.CreateAsync(produtos);

            return produtos;
        }

        [HttpPut]
        public async Task AtualizarAsync(string id, Produtos produtos) =>
            await _produtoService.UpdateAsync(id, produtos);

        [HttpDelete]
        public async Task DeletarAsync(string id) =>
            await _produtoService.DeleteAsync(id);
    }
}
