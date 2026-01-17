using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Contexto;
using IteraDisc.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IteraDisc.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositorio
    {
        public ProdutoRepositorio(IteraDiscContexto contexto) : base(contexto)
        {
        }

        public async Task<int> Salvar(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            await _contexto.SaveChangesAsync();

            return produto.ProdutoId;
        }
        public async Task Atualizar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Listar(bool ativo)
        {
            return await _contexto.Produtos.Where(p => p.Ativo == ativo).ToListAsync();
        }

        public async Task<Produto> Obter(int produtoId, bool ativo)
        {
            return await _contexto.Produtos
                    .Where(p => p.ProdutoId == produtoId)
                    .Where(p => p.Ativo == ativo)
                    .FirstOrDefaultAsync();
        }
    }
}