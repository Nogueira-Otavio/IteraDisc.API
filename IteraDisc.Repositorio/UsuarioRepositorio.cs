using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Contexto;
using IteraDisc.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IteraDisc.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IteraDiscContexto contexto) : base(contexto)
        { }

        public async Task<int> Salvar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();

            return usuario.UsuarioId;
        }

        public async Task Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Usuario> Obter(int usuarioId, bool ativo)
        {
            return await _contexto.Usuarios
                    .Where(usuario => usuario.UsuarioId == usuarioId)
                    .Where(u => u.Ativo == ativo)
                    .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmail(string usuarioEmail)
        {
            return await _contexto.Usuarios
            .Where(usuario => usuario.Email == usuarioEmail)
            .Where(u => u.Ativo)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> Listar(bool ativo)
        {
            return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
        }
    }
}