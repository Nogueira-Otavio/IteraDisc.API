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

        public Task Atualizar(ItemVenda itemVenda)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Criar(ItemVenda itemVenda)
        {
            _contexto.ItemVendas.Add(itemVenda);
            await _contexto.SaveChangesAsync();

            return itemVenda.ItemVendaId;
        }

        public async Task<IEnumerable<ItemVenda>> Listar()
        {
            return await _contexto.ItemVendas.ToListAsync();
        }

        public async Task<ItemVenda> Obter(int itemVendaId)
        {
            return await _contexto.ItemVendas
                    .Where(iv => iv.ItemVendaId == itemVendaId)
                    .FirstOrDefaultAsync();
        }
    }
}