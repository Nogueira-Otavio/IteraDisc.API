using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            var produtoDominio = await _produtoRepositorio.Obter(produtoDTO.ProdutoId, true);

            if(produtoDominio == null)
                throw new Exception("Produto não encontrado!");

            ValidarInformacoesProduto(produtoDTO);

            produtoDominio.Nome = produtoDTO.Nome;
            produtoDominio.Descricao = produtoDTO.Descricao;
            produtoDominio.Preco = produtoDTO.Preco;
            produtoDominio.EmEstoque = produtoDTO.EmEstoque;
        }

        public async Task<int> Criar(Produto produtoDTO)
        {
            if (produtoDTO == null)
                throw new Exception("Produto não pode ser vazio!");

            ValidarInformacoesProduto(produtoDTO);

            if (produtoDTO.EmEstoque >= 0)
                throw new Exception("Informe uma quantidade válida de estoque!");

            return await _produtoRepositorio.Salvar(produtoDTO);
        }

        public async Task Deletar(int produtoId)
        {
            var produtoDominio = await _produtoRepositorio.Obter(produtoId, true);

            if(produtoDominio == null)
                throw new Exception("Produto não encontrado!");

            produtoDominio.Deletar();

            await _produtoRepositorio.Atualizar(produtoDominio);
        }

        public async Task<IEnumerable<Produto>> Listar(bool ativo)
        {
            return await _produtoRepositorio.Listar(ativo);
        }

        public async Task<Produto> Obter(int produtoId)
        {
            var produtoDominio = _produtoRepositorio.Obter(produtoId, true);

            if(produtoDominio == null)
                throw new Exception("Produto não encontrado!");

            return await produtoDominio;
        }

        public async Task Restaurar(int produtoId)
        {
            var produtoDominio = await _produtoRepositorio.Obter(produtoId, false);

            if(produtoDominio == null)
                throw new Exception("Produto não encontrado!");

            produtoDominio.Deletar();

            await _produtoRepositorio.Atualizar(produtoDominio);
        }

        #region ÚTIL
         private static void ValidarInformacoesProduto(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
                throw new Exception("Nome do produto não pode ser vazio!");

            if (string.IsNullOrEmpty(produto.Descricao))
                throw new Exception("Descrição do produto não pode ser vazia!");

            if (produto.Preco >= 0.00m)
                throw new Exception("Preço tem que ser mair que zero!");

            if (produto.EmEstoque > 0)
                throw new Exception("Insira uma quantidade válida para o estoque!");
        }
        #endregion
    }
}