using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Interfaces;

namespace IteraDisc.Aplicacao
{
    public class ProdutoAplicaco : IProdutoAplicao
    {
        readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoAplicaco(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task Atualizar(Produto produtoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Criar(Produto produtoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task Deletar(int produtoId)
        {
            throw new NotImplementedException();
        }

        public async Task GerenciarEstoque(Produto produtoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> Listar(bool ativo)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> Obter(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task Restaurar(int produtoId)
        {
            throw new NotImplementedException();
        }

        #region ÚTIL
         private static void ValidarInformacoesUsuario(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
                throw new Exception("Nome do produto não pode ser vazio!");

            if (string.IsNullOrEmpty(produto.Descricao))
                throw new Exception("Descrição do produto não pode ser vazia!");
        }
        #endregion
    }
}