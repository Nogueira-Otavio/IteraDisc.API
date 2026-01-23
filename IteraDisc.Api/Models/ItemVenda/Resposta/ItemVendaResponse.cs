using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.Produtos.Resposta;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Api.Models.ItemVenda.Resposta
{
    public class ItemVendaResponse
    {
        public int ItemVendaId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoResponseDTO Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItemVenda { get; set; }
        public bool Vendido { get; set; }
        public int? VendaId { get; set; }
    }
}