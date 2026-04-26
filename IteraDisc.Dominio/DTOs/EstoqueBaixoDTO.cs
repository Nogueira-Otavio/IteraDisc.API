namespace IteraDisc.Dominio.DTOs
{
    public class EstoqueBaixoDTO
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int EmEstoque { get; set; }
    }
}