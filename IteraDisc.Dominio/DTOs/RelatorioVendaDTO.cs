namespace IteraDisc.Dominio.DTOs
{
    public class RelatorioVendaDTO
    {
        public int VendaId { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public int TotalItens { get; set; }
    }
}