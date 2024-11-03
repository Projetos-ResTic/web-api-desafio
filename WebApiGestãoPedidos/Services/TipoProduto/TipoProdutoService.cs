using Microsoft.EntityFrameworkCore;
using WebApiGestãoPedidos.Data;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.TipoProduto
{
    public class TipoProdutoService: ITipoProdutoInterface
    {
        private readonly AppDbContext _context;
        public TipoProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<TipoProdutoModel>>> AdicionarTipoProduto(TipoProdutoModel tipoProdutoModel)
        {
            ResponseModel<List<TipoProdutoModel>> resposta = new ResponseModel<List<TipoProdutoModel>>();

            try
            {

                var tipoProduto = new TipoProdutoModel
                {
                    Id = tipoProdutoModel.Id,
                    Nome = tipoProdutoModel.Nome,
                    Produtos = new List<ProdutoModel>()
                };

                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.TipoProduto.ToListAsync();
                resposta.Mensagem = "Tipo de produto adicionado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TipoProdutoModel>>> EditarTipoProduto(TipoProdutoModel tipoProdutoModel)
        {
            ResponseModel<List<TipoProdutoModel>> resposta = new ResponseModel<List<TipoProdutoModel>>();

            try
            {
                var tipoProduto = await _context.TipoProduto.FirstOrDefaultAsync(tipoProdutoBanco => tipoProdutoBanco.Id == tipoProdutoModel.Id);
                if (tipoProduto == null)
                {
                    resposta.Mensagem = "Nenhum status de pedido localizado!";
                    return resposta;
                }


                tipoProduto.Id = tipoProdutoModel.Id;
                tipoProduto.Nome = tipoProdutoModel.Nome;


                _context.Update(tipoProduto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.TipoProduto.ToListAsync();
                resposta.Mensagem = "Tipo de produto editado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TipoProdutoModel>>> ExcluirTipoProduto(int idTipoProduto)
        {
            ResponseModel<List<TipoProdutoModel>> resposta = new ResponseModel<List<TipoProdutoModel>>();
            try
            {
                var tipoProduto = await _context.TipoProduto.FirstOrDefaultAsync(pedidoBanco => pedidoBanco.Id == idTipoProduto);

                if (tipoProduto == null)
                {
                    resposta.Mensagem = "Nenhum tipo de produto localizado!";
                    return resposta;
                }

                _context.Remove(tipoProduto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.TipoProduto.ToListAsync();
                resposta.Mensagem = "Tipo de produto removido!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TipoProdutoModel>>> ListarTipoProduto()
        {
            ResponseModel<List<TipoProdutoModel>> resposta = new ResponseModel<List<TipoProdutoModel>>();
            try
            {
                var tipoProduto = await _context.TipoProduto.ToListAsync();

                resposta.Dados = tipoProduto;
                resposta.Mensagem = "Todos os tipos de produtos foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
