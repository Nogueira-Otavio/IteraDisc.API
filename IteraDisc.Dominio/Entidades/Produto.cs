using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Enumeradores;

namespace IteraDisc.Dominio.Entidades
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int EmEstoque { get; set; }
        public List<GenerosMusicais> GenerosMusicais { get; set; }
    }
}