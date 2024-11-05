using Microsoft.EntityFrameworkCore;
using WebApiGestãoPedidos.Data;
using WebApiGestãoPedidos.Dto.Pedido;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.Pedido
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<PedidoModel>>> AdicionarPedido(PedidoCriacaoDto pedidoCriacaoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedido = new PedidoModel()
                {
                    ClienteId = pedidoCriacaoDto.ClienteId,
                    StatusPedidoId = pedidoCriacaoDto.StatusPedidoId,
                    DataPedido = pedidoCriacaoDto.DataPedido
                };

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedido.ToListAsync();
                resposta.Mensagem = "Pedido adicionado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PedidoModel>> BuscarPedidoPorId(int idPedido)
        {
            ResponseModel<PedidoModel> resposta = new ResponseModel<PedidoModel>();

            try
            {
                var pedido = await _context.Pedido.FirstOrDefaultAsync(pedidoBanco => pedidoBanco.Id == idPedido);
                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum registro de pedido localizado!";
                    return resposta;
                }

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> EditarPedido(PedidoEdicaoDto pedidoEdicaoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedido = await _context.Pedido.FirstOrDefaultAsync(pedidoBanco => pedidoBanco.Id == pedidoEdicaoDto.Id);
                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum pedido localizado!";
                    return resposta;
                }

                pedido.StatusPedidoId = pedidoEdicaoDto.StatusPedidoId;
                pedido.ClienteId = pedidoEdicaoDto.ClienteId;
                pedido.DataPedido = pedidoEdicaoDto.DataPedido;


                _context.Update(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedido.ToListAsync();
                resposta.Mensagem = "Pedido editado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ExcluirPedido(int idPedido)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();
            try
            {
                var pedido = await _context.Pedido.FirstOrDefaultAsync(pedidoBanco => pedidoBanco.Id == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum pedido localizado!";
                    return resposta;
                }

                _context.Remove(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedido.ToListAsync();
                resposta.Mensagem = "Pedido removido!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ListarPedidos()
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();
            try
            {
                var pedidos = await _context.Pedido
                    .Include(p => p.StatusPedido)
                    .ToListAsync();

                resposta.Dados = pedidos;
                resposta.Mensagem = "Todos os pedidos foram coletados!";
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
