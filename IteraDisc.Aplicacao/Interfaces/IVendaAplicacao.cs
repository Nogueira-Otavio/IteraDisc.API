using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Aplicacao.Interfaces
{
    public interface IVendaAplicacao
    {
        Task<int> Criar(Venda venda);
        Task<Venda> Obter(int vendaId);
        Task<IEnumerable<Venda>> Listar();
        Task<IEnumerable<Venda>> HistoricoCliente(int usuarioId);
    }
}