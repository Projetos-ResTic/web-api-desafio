using WebApiGestãoPedidos.Dto.Cliente;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<ClienteModel>> BuscarClientePorId(int idCliente);
        Task<ResponseModel<ClienteModel>> BuscarClientePorIdPedido(int idPedido);
        Task<ResponseModel<List<ClienteModel>>> AdicionarCliente(ClienteCriacaoDto clienteCriacaoDto);
        Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto);
        Task<ResponseModel<List<ClienteModel>>> ExcluirCliente(int idCliente);
    }
}
