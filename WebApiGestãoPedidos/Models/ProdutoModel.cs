using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiGestãoPedidos.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public int TipoId { get; set; }

        [JsonIgnore]
        public TipoProdutoModel Tipo { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        [JsonIgnore]
        public ICollection<ItemPedidoModel> ItemsPedido { get; set; } = [];
    }
}
