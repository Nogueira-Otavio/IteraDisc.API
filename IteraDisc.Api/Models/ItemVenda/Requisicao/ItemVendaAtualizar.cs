using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Api.Models.ItemVenda.Requisicao
{
    public class ItemVendaAtualizar
    {
        public int ItemVendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItemVenda { get; set; }
        public bool Vendido { get; set; }
        public int VendaId { get; set; }
        public IteraDisc.Dominio.Entidades.Venda Venda { get; set; }
    }
}