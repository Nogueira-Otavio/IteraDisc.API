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
    public class VendaRepositorio : BaseRepositorio, IVendaRepositorio
    {
        public VendaRepositorio(IteraDiscContexto contexto) : base(contexto)
        {
        }

        public async Task<int> Criar(Venda venda)
        {
            _contexto.Vendas.Add(venda);
            await _contexto.SaveChangesAsync();

            return venda.VendaId;
        }

        public async Task<IEnumerable<Venda>> HistoricoCliente(int usuarioId)
        {
            return await _contexto.Vendas.Include(v => v.Itens).Where(v => v.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<Venda>> Listar()
        {
            return await _contexto.Vendas.Include(v => v.Itens).ToListAsync();
        }

        public async Task<Venda> Obter(int vendaId)
        {
            return await _contexto.Vendas
                        .Include(v => v.Itens)
                        .Where(venda => venda.VendaId == vendaId)
                        .FirstOrDefaultAsync();
        }
    }
}