using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGestãoPedidos.Dto.Cliente;
using WebApiGestãoPedidos.Models;
using WebApiGestãoPedidos.Services.Cliente;

namespace WebApiGestãoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("clientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await _clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("clientes/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorId(int idCliente)
        {
            var cliente = await _clienteInterface.BuscarClientePorId(idCliente);
            return Ok(cliente);
        }


        [HttpGet("clientes/pedido{idPedido}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorIdPedido(int idPedido)
        {
            var cliente = await _clienteInterface.BuscarClientePorIdPedido(idPedido);
            return Ok(cliente);
        }

        [HttpPost("adicionar/clientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> AdicionarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            var clientes = await _clienteInterface.AdicionarCliente(clienteCriacaoDto);
            return Ok(clientes);
        }


        [HttpPut("editar/clientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
        {
            var clientes = await _clienteInterface.EditarCliente(clienteEdicaoDto);
            return Ok(clientes);
        }

        [HttpDelete("deletar/clientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ExcluirCliente(int idCliente)
        {
            var clientes = await _clienteInterface.ExcluirCliente(idCliente);
            return Ok(clientes);
        }
    }
}
