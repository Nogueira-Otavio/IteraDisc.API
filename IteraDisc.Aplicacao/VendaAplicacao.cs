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

        public VendaAplicacao(IVendaRepositorio vendaRepositorio,IITemVendaRepositorio itemVendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
            _itemVendaRepositorio = itemVendaRepositorio;
        }

        public async Task<int> Criar(Venda vendaDTO)
        {
            var itemVendaDominio = await _itemVendaRepositorio.Listar(false);
            if(vendaDTO == null)
                throw new Exception("Venda não pode ser vazia!");
            
            int itensIguais = 0;
            foreach (var item in itemVendaDominio)
            {
                foreach (var itemVenda in vendaDTO.Itens)
                {
                    if( item.ItemVendaId == itemVenda.ItemVendaId)
                        itensIguais = itensIguais++;
                }
            }
            if(itensIguais < vendaDTO.Itens.Count)
                throw new Exception("Você passou itens não disponíveis para venda");
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