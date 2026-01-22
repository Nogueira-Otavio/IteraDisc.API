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

        public async Task<int> Criar(int usuarioId, List<int> itensIds)
        {
            if (itensIds == null || !itensIds.Any())
                throw new Exception("A venda deve conter ao menos um item.");

            var usuario = await _usuarioRepositorio.Obter(usuarioId, true);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            var venda = new Venda
            {
                UsuarioId = usuarioId,
                Usuario = usuario,
                DataVenda = DateTime.Now,
                ValorTotalVenda = 0
            };

            await _vendaRepositorio.Criar(venda);

            decimal total = 0;

            foreach (var itemId in itensIds)
            {
                var item = await _itemVendaRepositorio.Obter(itemId, false);

                if (item == null)
                    throw new Exception($"ItemVenda {itemId} não existe ou já foi vendido.");

                item.Vendido = true;
                item.VendaId = venda.VendaId;

                await _itemVendaRepositorio.Atualizar(item);

                venda.Itens.Add(item);
                total += item.ValorItemVenda;
            }

            venda.ValorTotalVenda = total;
            await _vendaRepositorio.Atualizar(venda);

            return venda.VendaId;
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