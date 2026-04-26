namespace IteraDisc.Repositorio.Interfaces
{
    public interface IDapperUsuarioRepositorio
    {
        Task<decimal> TotalVendasUsuario(int usuarioId);
    }
}