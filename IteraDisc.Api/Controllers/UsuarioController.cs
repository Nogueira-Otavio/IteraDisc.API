using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Api.Models.Usuarios.Requisicao;
using IteraDisc.Api.Models.Usuarios.Resposta;

namespace IteraDisc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuarioCriar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha
                };

                var usuarioID = await _usuarioAplicacao.Criar(usuarioDominio);

                return Ok(usuarioID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> Obter([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.Obter(usuarioId);

                var usuario = new UsuarioResponse()
                {
                    UsuarioId = usuarioDominio.UsuarioId,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email
                };

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuarioAtualizar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    UsuarioId = usuarioAtualizar.UsuarioId,
                    Nome = usuarioAtualizar.Nome,
                    Email = usuarioAtualizar.Email
                };

               await _usuarioAplicacao.Atualizar(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AlterarSenha")]
        public async Task<ActionResult> AlterarSenha([FromBody] UsuarioAtualizarSenha usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    UsuarioId = usuario.UsuarioId,
                    Senha = usuario.Senha
                };

                await _usuarioAplicacao.AtualizarSenha(usuarioDominio, usuario.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.Deletar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.Restaurar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> List([FromQuery] bool ativos)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.Listar(ativos);

                var usuarios = usuarioDominio.Select(u => new UsuarioResponse()
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}