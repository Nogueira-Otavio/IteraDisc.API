using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Dominio.Entidades
{
    public class Venda
    {
        public int VendaId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotalVenda { get; set; }

        public List<int> ItensId { get; set; }
        public List<ItemVenda> Itens { get; set; }

        public Venda()
        {
            Itens = new List<ItemVenda>();
            ItensId = new List<int>();
        }
    }
}