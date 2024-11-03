using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGestãoPedidos.Models;
using WebApiGestãoPedidos.Services.TipoProduto;

namespace WebApiGestãoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly ITipoProdutoInterface _tipoProdutoInterface;
        public TipoProdutoController(ITipoProdutoInterface tipoProdutoInterface)
        {
            _tipoProdutoInterface = tipoProdutoInterface;
        }

        [HttpGet("ListarTipoProduto")]
        public async Task<ActionResult<ResponseModel<List<TipoProdutoModel>>>> ListarTipoProduto()
        {
            var tipoProduto = await _tipoProdutoInterface.ListarTipoProduto();
            return Ok(tipoProduto);
        }

        [HttpPost("AdicionarTipoProduto")]
        public async Task<ActionResult<ResponseModel<List<TipoProdutoModel>>>> AdicionarTipoProduto(TipoProdutoModel tipoProdutoModel)
        {
            var tipoProduto = await _tipoProdutoInterface.AdicionarTipoProduto(tipoProdutoModel);
            return Ok(tipoProduto);
        }


        [HttpPut("EditarTipoProduto")]
        public async Task<ActionResult<ResponseModel<List<TipoProdutoModel>>>> EditarTipoProduto(TipoProdutoModel tipoProdutoModel)
        {
            var tipoProduto = await _tipoProdutoInterface.EditarTipoProduto(tipoProdutoModel);
            return Ok(tipoProduto);
        }

        [HttpDelete("ExcluirTipoProduto")]
        public async Task<ActionResult<ResponseModel<List<TipoProdutoModel>>>> ExcluirTipoProduto(int idTipoProduto)
        {
            var tipoProduto = await _tipoProdutoInterface.ExcluirTipoProduto(idTipoProduto);
            return Ok(tipoProduto);
        }
    }
}
