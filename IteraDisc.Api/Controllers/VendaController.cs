using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.Venda.Requisicao;
using IteraDisc.Api.Models.Venda.Resposta;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IteraDisc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaAplicacao _vendaAplicacao;
        private readonly IItemVendaAplicacao _itemVendaAplicacao;
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public VendaController(IVendaAplicacao vendaAplicacao, IItemVendaAplicacao itemVendaAplicacao, IUsuarioAplicacao usuarioAplicacao)
        {
            _vendaAplicacao = vendaAplicacao;
            _itemVendaAplicacao = itemVendaAplicacao;
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] VendaCriar vendaCriar)
        {
            try
            {
                var vendaDominio = new Venda()
                {
                    UsuarioId = vendaCriar.UsuarioId,
                    Usuario = vendaCriar.Usuario,
                    DataVenda = vendaCriar.DataVenda,
                    ValorTotalVenda = vendaCriar.ValorTotalVenda,
                    Itens = vendaCriar.Itens
                };

                var vendaID = await _vendaAplicacao.Criar(vendaDominio);

                return Ok(vendaID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{vendaId}")]
        public async Task<ActionResult> Obter([FromRoute] int vendaId)
        {
            try
            {
                var vendaDominio = await _vendaAplicacao.Obter(vendaId);

                var venda = new VendaResponse()
                {
                    VendaId = vendaDominio.VendaId,
                    UsuarioId = vendaDominio.UsuarioId,
                    DataVenda = vendaDominio.DataVenda,
                    ValorTotalVenda = vendaDominio.ValorTotalVenda,
                    Itens = vendaDominio.Itens
                };

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar([FromQuery] Venda venda)
        {
            try
            {
                var vendaDominio = await _vendaAplicacao.Listar();

                var vendas = vendaDominio.Select(v => new VendaResponse()
                {
                    VendaId = v.VendaId,
                    UsuarioId = v.UsuarioId,
                    DataVenda = v.DataVenda,
                    ValorTotalVenda = v.ValorTotalVenda,
                    Itens = v.Itens
                }).ToList();

                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar/{usuarioId}")]
        public async Task<ActionResult> HistoricoCliente([FromQuery] int usuarioId)
        {
            try
            {
                var vendaDominio = await _vendaAplicacao.HistoricoCliente(usuarioId);

                var vendas = vendaDominio.Select(v => new VendaResponse()
                {
                    VendaId = v.VendaId,
                    UsuarioId = v.UsuarioId,
                    DataVenda = v.DataVenda,
                    ValorTotalVenda = v.ValorTotalVenda,
                    Itens = v.Itens
                }).ToList();

                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}