namespace IteraDisc.Dominio.DTOs
{
    public class HistoricoVendaDTO
    {
        public int VendaId { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItemVenda { get; set; }
    }
}