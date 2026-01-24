using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Repositorio.Interfaces
{
    public interface IITemVendaRepositorio
    {
        Task<int> Criar(ItemVenda itemVenda);
        Task Atualizar(ItemVenda itemVenda);
        Task<ItemVenda> Obter(int itemVendaId, bool vendido, bool descartado);
        Task<IEnumerable<ItemVenda>> Listar(bool vendido, bool descartad);
    }
}