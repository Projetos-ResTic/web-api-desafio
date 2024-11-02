using System.Text.Json.Serialization;

namespace WebApiGestãoPedidos.Models
{
    public class ItemPedidoModel
    {
        public int ProdutoId { get; set; }

        [JsonIgnore]
        public ProdutoModel Produto { get; set; }

        public int PedidoId { get; set; }

        [JsonIgnore]
        public PedidoModel Pedido { get; set; }

        public int Quantidade { get; set; }
    }
}
