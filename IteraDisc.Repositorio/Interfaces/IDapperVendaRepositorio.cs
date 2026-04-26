using IteraDisc.Dominio.DTOs;

namespace IteraDisc.Repositorio.Interfaces
{
    public interface IDapperVendaRepositorio
    {
        Task<IEnumerable<RelatorioVendaDTO>> RelatorioVendasPorPeriodo(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<HistoricoVendaDTO>> HistoricoCompleto();
    }
}