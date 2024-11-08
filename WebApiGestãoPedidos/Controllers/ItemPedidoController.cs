﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGestãoPedidos.Dto.ItemPedido;
using WebApiGestãoPedidos.Models;
using WebApiGestãoPedidos.Services.ItemPedido;

namespace WebApiGestãoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoInterface _itemPedidoInterface;
        public ItemPedidoController(IItemPedidoInterface itemPedidoInterface)
        {
            _itemPedidoInterface = itemPedidoInterface;
        }

        [HttpGet("itens-pedidos")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> ListarItemPedido()
        {
            var itemPedido = await _itemPedidoInterface.ListarItemPedido();
            return Ok(itemPedido);
        }

        [HttpPost("adicionar/itens-pedidos")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> AdicionarItemPedido(ItemPedidoDto itemPedidoCriacaoDto)
        {
            var itemPedido = await _itemPedidoInterface.AdicionarItemPedido(itemPedidoCriacaoDto);
            return Ok(itemPedido);
        }


        [HttpPut("editar/itens-pedidos")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> EditarItemPedido(ItemPedidoDto itemPedidoEdicaoDto)
        {
            var itemPedido = await _itemPedidoInterface.EditarItemPedido(itemPedidoEdicaoDto);
            return Ok(itemPedido);
        }

        [HttpDelete("deletar/itens-pedidos")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ExcluirItemPedido(int produtoId, int pedidoId)
        {
            var itemPedido = await _itemPedidoInterface.ExcluirItemPedido(produtoId, pedidoId);
            return Ok(itemPedido);
        }
    }
}
