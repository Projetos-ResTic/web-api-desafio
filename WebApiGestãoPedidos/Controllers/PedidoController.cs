using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGestãoPedidos.Dto.Pedido;
using WebApiGestãoPedidos.Models;
using WebApiGestãoPedidos.Services.Pedido;

namespace WebApiGestãoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoInterface _pedidoInterface;
        public PedidoController(IPedidoInterface pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ListarPedidos()
        {
            var pedidos = await _pedidoInterface.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpPost("AdicionarPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> AdicionarPedido(PedidoCriacaoDto pedidoCriacaoDto)
        {
            var pedidos = await _pedidoInterface.AdicionarPedido(pedidoCriacaoDto);
            return Ok(pedidos);
        }


        [HttpPut("EditarPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> EditarPedido(PedidoEdicaoDto pedidoEdicaoDto)
        {
            var pedidos = await _pedidoInterface.EditarPedido(pedidoEdicaoDto);
            return Ok(pedidos);
        }


        [HttpDelete("ExcluirPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ExcluirPedido(int idPedido)
        {
            var pedidos = await _pedidoInterface.ExcluirPedido(idPedido);
            return Ok(pedidos);
        }
    }
}
