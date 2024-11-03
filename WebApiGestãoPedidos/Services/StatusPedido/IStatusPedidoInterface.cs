using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.StatusPedido
{
    public interface IStatusPedidoInterface
    {
        Task<ResponseModel<List<StatusPedidoModel>>> ListarStatusPedidos();

        Task<ResponseModel<List<StatusPedidoModel>>> AdicionarStatusPedido(StatusPedidoModel statusPedidoModel);

        Task<ResponseModel<List<StatusPedidoModel>>> EditarStatusPedido(StatusPedidoModel statusPedidoModel);
        Task<ResponseModel<List<StatusPedidoModel>>> ExcluirStatusPedido(int idStatusPedido);
    }
}
