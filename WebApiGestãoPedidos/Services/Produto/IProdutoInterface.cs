using WebApiGestãoPedidos.Dto.Produto;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> ListarProduto();
        Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto);
        Task<ResponseModel<List<ProdutoModel>>> AdicionarProduto(ProdutoCriacaoDto produtoCriacaoDto);
        Task<ResponseModel<List<ProdutoModel>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto);
        Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto);
    }
}
