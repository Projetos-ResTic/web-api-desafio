using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.TipoProduto
{
    public interface ITipoProdutoInterface
    {

        Task<ResponseModel<List<TipoProdutoModel>>> ListarTipoProduto();
        Task<ResponseModel<List<TipoProdutoModel>>> AdicionarTipoProduto(TipoProdutoModel tipoProdutoModel);
        Task<ResponseModel<List<TipoProdutoModel>>> EditarTipoProduto(TipoProdutoModel tipoProdutoModel);
        Task<ResponseModel<List<TipoProdutoModel>>> ExcluirTipoProduto(int idTipoProduto);
    }
}
