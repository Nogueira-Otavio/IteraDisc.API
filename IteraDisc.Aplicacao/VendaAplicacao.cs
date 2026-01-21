using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Interfaces;

namespace IteraDisc.Aplicacao
{
    public class VendaAplicacao : IVendaAplicacao
    {
        readonly IVendaRepositorio _vendaRepositorio;
        readonly IITemVendaRepositorio _itemVendaRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public VendaAplicacao(IVendaRepositorio vendaRepositorio,IITemVendaRepositorio itemVendaRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
            _itemVendaRepositorio = itemVendaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<int> Criar(Venda vendaDTO)
        {
            var itemVendaDominio = await _itemVendaRepositorio.Listar(false);
            var usarioDominio = await _usuarioRepositorio.Obter(vendaDTO.UsuarioId, true);
            if(vendaDTO == null)
                throw new Exception("Venda não pode ser vazia!");
            
            int itensIguais = 0;
            foreach (var item in itemVendaDominio)
            {
                foreach (int itemVenda in vendaDTO.ItensId)
                {
                    if( item.ItemVendaId == itemVenda)
                    {
                        var itemVendaId = await _itemVendaRepositorio.Obter(itemVenda, false);
                        itemVendaId.Vendido = true;
                        await _itemVendaRepositorio.Atualizar(itemVendaId);
                        itensIguais = itensIguais++;
                        vendaDTO.Itens.Add( new ItemVenda()
                        {
                            ItemVendaId = itemVendaId.ItemVendaId,
                            ProdutoId = itemVendaId.ProdutoId,
                            Produto = itemVendaId.Produto,
                            Quantidade = itemVendaId.Quantidade,
                            ValorItemVenda = itemVendaId.ValorItemVenda,
                            Vendido = itemVendaId.Vendido,
                        });
                    }
                }
            }
            if(itensIguais < vendaDTO.Itens.Count)
                throw new Exception("Você passou itens não disponíveis para venda");

            if(usarioDominio == null)
                throw new Exception("Usuário não encontrado!");
            
            vendaDTO.Usuario = usarioDominio;

            return await _vendaRepositorio.Criar(vendaDTO);
        }

        public async Task<IEnumerable<Venda>> HistoricoCliente(int usuarioId)
        {
            return await _vendaRepositorio.HistoricoCliente(usuarioId);
        }

        public async Task<IEnumerable<Venda>> Listar()
        {
            return await _vendaRepositorio.Listar();
        }

        public async Task<Venda> Obter(int vendaId)
        {
            var vendaDominio = _vendaRepositorio.Obter(vendaId);

            if(vendaDominio == null)
                throw new Exception("Venda não encontrada!");

            return await vendaDominio;
        }
    }
}