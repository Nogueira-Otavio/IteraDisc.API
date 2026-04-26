using IteraDisc.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;

namespace IteraDisc.Repositorio
{
    public class DapperUsuarioRepositorio : DapperRepositorio, IDapperUsuarioRepositorio
    {
        public DapperUsuarioRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<decimal> TotalVendasUsuario(int usuarioId)
        {
            return await ExecutarScalar<decimal>(
                "SELECT dbo.fn_TotalVendasUsuario(@UsuarioId)",
                new { UsuarioId = usuarioId }
            );
        }
    }
}