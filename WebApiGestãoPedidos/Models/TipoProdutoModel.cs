using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiGestãoPedidos.Models
{
    public class TipoProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }


        [JsonIgnore]
        public ICollection<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();
    }
}
