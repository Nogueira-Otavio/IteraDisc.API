using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Interfaces;

namespace IteraDisc.Aplicacao
{
    public class ItemVendaAplicacao : IItemVendaAplicacao
    {
        readonly IITemVendaRepositorio _iTemVendaRepositorio;
        readonly IProdutoRepositorio _produtoRepositorio;

        public ItemVendaAplicacao(IITemVendaRepositorio iTemVendaRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _iTemVendaRepositorio = iTemVendaRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task Atualizar(ItemVenda itemVenda)
        {
            var itemVendaDominio = await _iTemVendaRepositorio.Obter(itemVenda.ItemVendaId, false);
            var produtoDominio = await _produtoRepositorio.Obter(itemVenda.ProdutoId, true);

            if(itemVendaDominio == null)
                throw new Exception("ItemVenda não encontrado!");
            
            if(produtoDominio == null)
                throw new Exception("Produto não encontrado!");

            itemVendaDominio.Quantidade = itemVenda.Quantidade;

            if(itemVendaDominio.Quantidade <= 0)
                throw new Exception("Tem que haver no mínimo uma cópia do produto!");

            itemVendaDominio.ProdutoId = itemVenda.ProdutoId;
            itemVendaDominio.Quantidade = itemVenda.Quantidade;
            itemVendaDominio.ValorItemVenda = itemVenda.Quantidade * produtoDominio.Preco;

            await _iTemVendaRepositorio.Atualizar(itemVendaDominio);
        }

        public async Task<int> Criar(ItemVenda itemVendaDTO)
        {
            if (itemVendaDTO == null)
                throw new Exception("ItemVenda não pode ser vazio!");

            var produtoDominio = await _produtoRepositorio.Obter(itemVendaDTO.ProdutoId, true);

            if(produtoDominio == null)
                throw new Exception("Produto não encontrado!");

            if(itemVendaDTO.Quantidade <= 0)
                throw new Exception("Informe uma quantidade válida!");

            if(itemVendaDTO.Quantidade > produtoDominio.EmEstoque)
                throw new Exception("Você está tentando comprar mais itens do que estão disponíveis no estoque!");
            
            itemVendaDTO.ValorItemVenda = produtoDominio.Preco * itemVendaDTO.Quantidade;

            return await _iTemVendaRepositorio.Criar(itemVendaDTO);
        }

        public async Task<IEnumerable<ItemVenda>> Listar(bool vendido)
        {
            return await _iTemVendaRepositorio.Listar(vendido);
        }

        public async Task<ItemVenda> Obter(int itemVendaId, bool vendido)
        {
            var itemVendaDominio = _iTemVendaRepositorio.Obter(itemVendaId, vendido);

            if(itemVendaDominio == null)
                throw new Exception("ItemVenda não encontrado!");

            return await itemVendaDominio;
        }
    }
}