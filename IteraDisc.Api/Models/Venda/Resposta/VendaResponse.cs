using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.ItemVenda.Resposta;
using IteraDisc.Repositorio;

namespace IteraDisc.Api.Models.Venda.Resposta
{
    public class VendaResponse
    {
        public int VendaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public List<ItemVendaResponse> Itens { get; set; }
    }
}