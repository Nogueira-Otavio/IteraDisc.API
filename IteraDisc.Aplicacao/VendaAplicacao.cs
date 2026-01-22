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
        readonly IProdutoRepositorio _produtoRepositorio;

        public VendaAplicacao(IVendaRepositorio vendaRepositorio, IITemVendaRepositorio itemVendaRepositorio, IUsuarioRepositorio usuarioRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
            _itemVendaRepositorio = itemVendaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<int> Criar(Venda vendaDTO)
        {
            if (vendaDTO == null)
                throw new Exception("Venda não pode ser vazia!");

            var usuarioDominio = await _usuarioRepositorio.Obter(vendaDTO.UsuarioId, true);
            if (usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            vendaDTO.Usuario = usuarioDominio;
            vendaDTO.Itens = new List<ItemVenda>();

            decimal valorTotal = 0;

            foreach (int itemVendaId in vendaDTO.ItensId)
            {
                // Busca o itemVenda que ainda não foi vendido
                var itemVendaDominio = await _itemVendaRepositorio.Obter(itemVendaId, false);

                if (itemVendaDominio == null)
                    throw new Exception($"O item de venda {itemVendaId} não existe ou já foi vendido.");

                // Marca como vendido
                itemVendaDominio.Vendido = true;
                itemVendaDominio.VendaId = vendaDTO.VendaId;

                await _itemVendaRepositorio.Atualizar(itemVendaDominio);

                // Adiciona na lista da venda
                vendaDTO.Itens.Add(itemVendaDominio);

                // Soma no total da venda
                valorTotal += itemVendaDominio.ValorItemVenda;
            }

            vendaDTO.ValorTotalVenda = valorTotal;
            vendaDTO.DataVenda = DateTime.Now;

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

            if (vendaDominio == null)
                throw new Exception("Venda não encontrada!");

            return await vendaDominio;
        }
    }
}