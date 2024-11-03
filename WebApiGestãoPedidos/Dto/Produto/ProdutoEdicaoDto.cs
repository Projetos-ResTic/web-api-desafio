namespace WebApiGestãoPedidos.Dto.Produto
{
    public class ProdutoEdicaoDto
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
