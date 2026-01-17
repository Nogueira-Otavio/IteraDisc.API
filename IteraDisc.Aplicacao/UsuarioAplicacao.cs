using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Interfaces;

namespace IteraDisc.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<int> Criar(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception("Usúario não pode ser vazio!");

            ValidarInformacoesUsuario(usuario);

            if (string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("Senha do usúario não pode ser vazia!");

            return await _usuarioRepositorio.Salvar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            var usuarioDominio = await _usuarioRepositorio.Obter(usuario.UsuarioId, true);

            if(usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            ValidarInformacoesUsuario(usuario);

            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Email = usuario.Email;

            await _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task AtualizarSenha(Usuario usuario, string senhaAntiga)
        {
            var usuarioDominio = await _usuarioRepositorio.Obter(usuario.UsuarioId, true);

            if(usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            if(usuarioDominio.Senha != senhaAntiga)
                throw new Exception("Senha antiga inválida!");

            usuarioDominio.Senha = usuario.Senha;

            await _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task<Usuario> Obter(int usuarioId)
        {
            var usuarioDominio = _usuarioRepositorio.Obter(usuarioId, true);

            if(usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            return await usuarioDominio;
        }

         public async Task<Usuario> ObterPorEmail(string email)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPorEmail(email);

            if(usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            return await usuarioDominio;
        }

        public async Task Deletar(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId, true);

            if(usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            usuarioDominio.Deletar();

            await _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task Restaurar(int usuarioId)
        {
            var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId, false);

            if(usuarioDominio == null)
                throw new Exception("Usuário não encontrado!");

            usuarioDominio.Restaurar();

            await _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public async Task<IEnumerable<Usuario>> Listar(bool ativo)
        {
            return await _usuarioRepositorio.Listar(ativo);
        }

        #region ÚTIL
        private static void ValidarInformacoesUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome))
                throw new Exception("Nome do usúario não pode ser vazio!");

            if (string.IsNullOrEmpty(usuario.Email))
                throw new Exception("E-mail do usúario não pode ser vazio!");
        }
        #endregion
    }
}