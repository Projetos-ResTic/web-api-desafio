using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiGestãoPedidos.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NumeroContato { get; set; }
        public DateTime DataNascimento { get; set; }

        [JsonIgnore]
        public ICollection<PedidoModel> Pedidos { get; set; }
    }
}

