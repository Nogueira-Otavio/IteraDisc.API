using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.ItemVenda.Requisicao;
using IteraDisc.Api.Models.ItemVenda.Resposta;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IteraDisc.Api.Controllers
{
    [Route("[controller]")]
    public class ItemVendaController : Controller
    {
        private readonly IItemVendaAplicacao _itemVendaAplicacao;

        public ItemVendaController(IItemVendaAplicacao itemVendaAplicacao)
        {
            _itemVendaAplicacao = itemVendaAplicacao;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] ItemVendaCriar itemVendaCriar)
        {
            try
            {
                var itemVendaDominio = new ItemVenda()
                {
                    ProdutoId = itemVendaCriar.ProdutoId,
                    Quantidade = itemVendaCriar.Quantidade,
                    ValorItemVenda = itemVendaCriar.ValorItemVenda
                };

                var itemVendaID = await _itemVendaAplicacao.Criar(itemVendaDominio);

                return Ok(itemVendaID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] ItemVendaAtualizar itemVendaAtualizar)
        {
            try
            {
                var itemVendaDominio = new ItemVenda()
                {
                    ItemVendaId = itemVendaAtualizar.ItemVendaId,
                    ProdutoId = itemVendaAtualizar.ProdutoId,
                    Quantidade = itemVendaAtualizar.Quantidade,
                    ValorItemVenda = itemVendaAtualizar.ValorItemVenda
                };

               await _itemVendaAplicacao.Atualizar(itemVendaDominio);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{itemVendaId}")]
        public async Task<ActionResult> Obter([FromRoute] int itemVendaId)
        {
            try
            {
                var itemVendaDominio = await _itemVendaAplicacao.Obter(itemVendaId);

                var itemVenda = new ItemVenda()
                {
                    ItemVendaId = itemVendaDominio.ItemVendaId,
                    ProdutoId = itemVendaDominio.ProdutoId,
                    Quantidade = itemVendaDominio.Quantidade,
                    ValorItemVenda = itemVendaDominio.ValorItemVenda
                };

                return Ok(itemVenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> List([FromQuery] ItemVenda itemVenda)
        {
            try
            {
                var itemVendaDominio = await _itemVendaAplicacao.Listar();

                var itensVenda = itemVendaDominio.Select(iv => new ItemVendaResponse()
                {
                    ItemVendaId = iv.ItemVendaId,
                    ProdutoId = iv.ProdutoId,
                    Quantidade = iv.Quantidade,
                    ValorItemVenda = iv.ValorItemVenda
                }).ToList();

                return Ok(itensVenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}