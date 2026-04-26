using IteraDisc.Dominio.DTOs;
using IteraDisc.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;

namespace IteraDisc.Repositorio
{
    public class DapperProdutoRepositorio : DapperRepositorio, IDapperProdutoRepositorio
    {
        public DapperProdutoRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<EstoqueBaixoDTO>> ProdutosEstoqueBaixo(int limite)
        {
            return await ExecutarProcedure<EstoqueBaixoDTO>(
                "sp_ProdutosEstoqueBaixo",
                new { LimiteEstoque = limite }
            );
        }
    }
}