using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Api.Models.Venda.Requisicao
{
    public class VendaCriar
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public List<IteraDisc.Dominio.Entidades.ItemVenda> Itens { get; set; }
    }
}