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
        public List<int> Itens { get; set; }
    }
}