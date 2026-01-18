using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;

namespace IteraDisc.Aplicacao.Interfaces
{
    public interface IProdutoAplicao
    {
        Task<int> Criar(Produto produtoDTO);
        Task Atualizar(Produto produtoDTO);
        Task Deletar(int produtoId);
        Task Restaurar(int produtoId);
        Task<IEnumerable<Produto>> Listar(bool ativo);
        Task<Produto> Obter(int produtoId);
    }
}