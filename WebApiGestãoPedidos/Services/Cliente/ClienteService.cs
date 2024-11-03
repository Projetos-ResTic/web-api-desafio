using Microsoft.EntityFrameworkCore;
using WebApiGestãoPedidos.Data;
using WebApiGestãoPedidos.Dto.Cliente;
using WebApiGestãoPedidos.Models;

namespace WebApiGestãoPedidos.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ClienteModel>>> AdicionarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

            try
            {
                var cliente = new ClienteModel()
                {
                    Nome = clienteCriacaoDto.Nome,
                    Email = clienteCriacaoDto.Email,
                    NumeroContato = clienteCriacaoDto.NumeroContato,
                    DataNascimento = clienteCriacaoDto.DataNascimento
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente adicionado com sucesso!";
                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> BuscarClientePorId(int idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == idCliente);
                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum registro de cliente localizado!";
                    return resposta;
                }

                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente localizado!";
                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> BuscarClientePorIdPedido(int idPedido)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var pedido = await _context.Pedido
                    .Include(c => c.Cliente)
                    .FirstOrDefaultAsync(pedidoBanco => pedidoBanco.Id == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum registro de cliente localizado!";
                    return resposta;
                }

                resposta.Dados = pedido.Cliente;
                resposta.Mensagem = "Cliente localizado!";
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == clienteEdicaoDto.Id);
                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum cliente localizado!";
                    return resposta;
                }

                cliente.Nome = clienteEdicaoDto.Nome;
                cliente.Email = clienteEdicaoDto.Email;
                cliente.NumeroContato = clienteEdicaoDto.NumeroContato;
                cliente.DataNascimento = clienteEdicaoDto.DataNascimento;

                _context.Update(cliente);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente editado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ExcluirCliente(int idCliente)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == idCliente);

                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum cliente localizado!";
                    return resposta;
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente removido!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var clientes = await _context.Cliente.ToListAsync();

                resposta.Dados = clientes;
                resposta.Mensagem = "Todos os clientes foram coletados!";
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
