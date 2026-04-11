using IteraDisc.Api.Models.Auth;
using IteraDisc.Api.Services;
using IteraDisc.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IteraDisc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;
        private readonly TokenService _tokenService;

        public AuthController(IUsuarioAplicacao usuarioAplicacao, TokenService tokenService)
        {
            _usuarioAplicacao = usuarioAplicacao;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequisicao requisicao)
        {
            try
            {
                var usuario = await _usuarioAplicacao.ObterPorEmail(requisicao.Email);

                if (usuario == null)
                    return Unauthorized("E-mail ou senha inválidos.");

                var senhaValida = BCrypt.Net.BCrypt.Verify(requisicao.Senha, usuario.Senha);
                if (!senhaValida)
                    return Unauthorized("E-mail ou senha inválidos.");

                var token = _tokenService.GerarToken(usuario);

                return Ok(new LoginResposta
                {
                    Token = token,
                    Nome = usuario.Nome,
                    UsuarioId = usuario.UsuarioId,
                    Perfil = usuario.Perfil
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}