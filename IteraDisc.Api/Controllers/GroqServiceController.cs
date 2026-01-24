using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.GroqService.Requisicao;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades.GroqService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IteraDisc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroqServiceController : ControllerBase
    {
        private readonly IGroqServiceAplicacao _groqServiceAplicacao;

        public GroqServiceController(IGroqServiceAplicacao groqServiceAplicacao)
        {
            _groqServiceAplicacao = groqServiceAplicacao;
        }

        [HttpPost]
        [Route("Enviar")]
        public async Task<ActionResult> Enviar([FromBody] ChatRequestDTO chatRequestDTO)
        {
            try
            {
                var resposta = await _groqServiceAplicacao.EnviarAsync(
                    chatRequestDTO.Mensagem
                );

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}