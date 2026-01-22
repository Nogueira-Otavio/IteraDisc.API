using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.ItemVenda.Resposta;

namespace IteraDisc.Api.Models.Venda.Resposta
{
    public class VendaResponseDTO
    {
        public int VendaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal ValorTotalVenda { get; set; }
    public List<ItemVendaResponseDTO> Itens { get; set; }
    }
}