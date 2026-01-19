using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Dominio.Entidades
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItemVenda { get; set; }
        public bool Vendido { get; set; }
        
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        public ItemVenda()
        {
            Vendido = false;
        }
    }
}