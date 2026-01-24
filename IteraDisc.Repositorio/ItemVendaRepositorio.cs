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
    public class ItemVendaRepositorio :BaseRepositorio, IITemVendaRepositorio
    {
        public ItemVendaRepositorio(IteraDiscContexto contexto) : base(contexto)
        {
        }

        public async Task Atualizar(ItemVenda itemVenda)
        {
            _contexto.ItemVendas.Update(itemVenda);
            await _contexto.SaveChangesAsync();
        }

        public async Task<int> Criar(ItemVenda itemVenda)
        {
            _contexto.ItemVendas.Add(itemVenda);
            await _contexto.SaveChangesAsync();

            return itemVenda.ItemVendaId;
        }

        public async Task<IEnumerable<ItemVenda>> Listar(bool vendido, bool descartado)
        {
            return await _contexto.ItemVendas
                        .Include(iv => iv.Produto)
                        .Where(itemVenda => itemVenda.Vendido == vendido)
                        .Where(itemVenda => itemVenda.Descartado == descartado)
                        .ToListAsync();
        }

        public async Task<ItemVenda> Obter(int itemVendaId, bool vendido, bool descartado)
        {
            return await _contexto.ItemVendas
                        .Include(iv => iv.Produto)
                        .Where(itemVenda => itemVenda.ItemVendaId == itemVendaId)
                        .Where(itemVenda => itemVenda.Vendido == vendido)
                        .Where(itemVenda => itemVenda.Descartado == descartado)
                        .FirstOrDefaultAsync();
        }
    }
}