using Microsoft.EntityFrameworkCore;
using WebApiGestãoPedidos.Data;
using WebApiGestãoPedidos.Dto.Produto;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProdutoModel>>> AdicionarProduto(ProdutoCriacaoDto produtoCriacaoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = new  ProdutoModel()
                {
                    TipoId = produtoCriacaoDto.TipoId,
                    Nome = produtoCriacaoDto.Nome,
                    Valor = produtoCriacaoDto.Valor
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Produto.ToListAsync();
                resposta.Mensagem = "Produto adicionado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();

            try
            {
                var produto = await _context.Produto.FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == idProduto);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro de produto localizado!";
                    return resposta;
                }

                resposta.Dados = produto;
                resposta.Mensagem = "Produto localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produto.FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == produtoEdicaoDto.Id);
                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum produto localizado!";
                    return resposta;
                }

                produto.Id = produtoEdicaoDto.Id;
                produto.TipoId = produtoEdicaoDto.TipoId;
                produto.Nome = produtoEdicaoDto.Nome;
                produto.Valor = produtoEdicaoDto.Valor;


                _context.Update(produto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Produto.ToListAsync();
                resposta.Mensagem = "Produto editado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produto = await _context.Produto.FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum produto localizado!";
                    return resposta;
                }

                _context.Remove(produto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Produto.ToListAsync();
                resposta.Mensagem = "Produto removido!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProduto()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produto = await _context.Produto.ToListAsync();

                resposta.Dados = produto;
                resposta.Mensagem = "Todos os produtos foram coletados!";
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
