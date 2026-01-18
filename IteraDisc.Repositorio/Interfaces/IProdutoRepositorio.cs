using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<int> Salvar(Produto produto);
        Task Atualizar(Produto produto);
        Task<Produto> Obter(int produtoId, bool ativo);
        Task<IEnumerable<Produto>> Listar(bool ativo);
    }
}