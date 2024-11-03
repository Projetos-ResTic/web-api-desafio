using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGestãoPedidos.Models;
using WebApiGestãoPedidos.Services.StatusPedido;

namespace WebApiGestãoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPedidoController : ControllerBase
    {
        private readonly IStatusPedidoInterface _statusPedidoInterface;
        public StatusPedidoController(IStatusPedidoInterface statusPedidoInterface)
        {
            _statusPedidoInterface = statusPedidoInterface;
        }

        [HttpGet("ListarStatusPedidos")]
        public async Task<ActionResult<ResponseModel<List<StatusPedidoModel>>>> ListarStatusPedidos()
        {
            var statusPedido = await _statusPedidoInterface.ListarStatusPedidos();
            return Ok(statusPedido);
        }

        [HttpPost("AdicionarStatusPedido")]
        public async Task<ActionResult<ResponseModel<List<StatusPedidoModel>>>> AdicionarStatusPedido(StatusPedidoModel statusPedidoModel)
        {
            var statusPedido = await _statusPedidoInterface.AdicionarStatusPedido(statusPedidoModel);
            return Ok(statusPedido);
        }


        [HttpPut("EditarStatusPedido")]
        public async Task<ActionResult<ResponseModel<List<StatusPedidoModel>>>> EditarStatusPedido(StatusPedidoModel statusPedidoModel)
        {
            var statusPedido = await _statusPedidoInterface.EditarStatusPedido(statusPedidoModel);
            return Ok(statusPedido);
        }

        [HttpDelete("ExcluirStatusPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ExcluirStatusPedido(int idStatusPedido)
        {
            var statusPedido = await _statusPedidoInterface.ExcluirStatusPedido(idStatusPedido);
            return Ok(statusPedido);
        }
    }
}
