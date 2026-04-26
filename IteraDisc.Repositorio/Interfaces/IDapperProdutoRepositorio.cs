using IteraDisc.Dominio.DTOs;

namespace IteraDisc.Repositorio.Interfaces
{
    public interface IDapperProdutoRepositorio
    {
        Task<IEnumerable<EstoqueBaixoDTO>> ProdutosEstoqueBaixo(int limite);
    }
}