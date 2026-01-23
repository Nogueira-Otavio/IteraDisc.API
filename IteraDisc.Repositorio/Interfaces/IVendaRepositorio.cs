using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Repositorio.Interfaces
{
    public interface IVendaRepositorio
    {
        Task<int> Criar(Venda venda);
        Task Atualizar(Venda venda);
        Task<Venda> Obter(int vendaId);
        Task<IEnumerable<Venda>> Listar();
        Task<IEnumerable<Venda>> HistoricoCliente(int usuarioId);
    }
}