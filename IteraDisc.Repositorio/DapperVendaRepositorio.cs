using IteraDisc.Dominio.DTOs;
using IteraDisc.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;

namespace IteraDisc.Repositorio
{
    public class DapperVendaRepositorio : DapperRepositorio, IDapperVendaRepositorio
    {
        public DapperVendaRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<RelatorioVendaDTO>> RelatorioVendasPorPeriodo(
            DateTime dataInicio,
            DateTime dataFim)
        {
            return await ExecutarProcedure<RelatorioVendaDTO>(
                "sp_RelatorioVendasPorPeriodo",
                new { DataInicio = dataInicio, DataFim = dataFim }
            );
        }

        public async Task<IEnumerable<HistoricoVendaDTO>> HistoricoCompleto()
        {
            return await ExecutarQuery<HistoricoVendaDTO>(
                "SELECT * FROM vw_HistoricoVendas ORDER BY DataVenda DESC"
            );
        }
    }
}