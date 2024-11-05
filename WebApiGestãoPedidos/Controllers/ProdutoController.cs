using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGestãoPedidos.Dto.Produto;
using WebApiGestãoPedidos.Models;
using WebApiGestãoPedidos.Services.Pedido;
using WebApiGestãoPedidos.Services.Produto;

namespace WebApiGestãoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProduto()
        {
            var produtos = await _produtoInterface.ListarProduto();
            return Ok(produtos);
        }

        [HttpGet("produtos/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> BuscarProdutoPorId(int idProduto)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(idProduto);
            return Ok(produto);
        }


        [HttpPost("adicionar/produtos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> AdicionarProduto(ProdutoCriacaoDto produtoCriacaoDto)
        {
            var produtos = await _produtoInterface.AdicionarProduto(produtoCriacaoDto);
            return Ok(produtos);
        }


        [HttpPut("editar/produtos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            var produtos = await _produtoInterface.EditarProduto(produtoEdicaoDto);
            return Ok(produtos);
        }


        [HttpDelete("deletar/produtos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ExcluirProduto(int idProduto)
        {
            var produtos = await _produtoInterface.ExcluirProduto(idProduto);
            return Ok(produtos);
        }
    }
}
