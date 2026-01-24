using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Aplicacao.Interfaces
{
    public interface IItemVendaAplicacao
    {
        Task<int> Criar(ItemVenda itemVenda);
        Task Atualizar(ItemVenda itemVenda);
        Task Descartar(int itemVendaId);
        Task<ItemVenda> Obter(int itemVendaId, bool vendidom, bool descartado);
        Task<IEnumerable<ItemVenda>> Listar(bool vendido, bool descartado);
    }
}