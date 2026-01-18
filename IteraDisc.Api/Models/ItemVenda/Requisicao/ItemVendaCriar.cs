using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteraDisc.Api.Models.ItemVenda.Requisicao
{
    public class ItemVendaCriar
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItemVenda { get; set; }
    }
}