using WebApiGestãoPedidos.Dto.ItemPedido;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.ItemPedido
{
    public interface IItemPedidoInterface
    {
        Task<ResponseModel<List<ItemPedidoModel>>> ListarItemPedido();
        Task<ResponseModel<List<ItemPedidoModel>>> AdicionarItemPedido(ItemPedidoDto itemPedidoCriacaoDto);
        Task<ResponseModel<List<ItemPedidoModel>>> EditarItemPedido(ItemPedidoDto itemPedidoEdicaoDto);
        Task<ResponseModel<List<ItemPedidoModel>>> ExcluirItemPedido(int produtoId, int pedidoId);
    }
}
