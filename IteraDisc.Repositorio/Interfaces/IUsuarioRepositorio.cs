using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<int> Salvar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task<Usuario> Obter(int usuarioId, bool ativo);
        Task<Usuario> ObterPorEmail(string email);
        Task<IEnumerable<Usuario>> Listar(bool ativo);
    }
}