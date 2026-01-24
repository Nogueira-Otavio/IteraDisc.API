using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.ItemVenda.Requisicao;
using IteraDisc.Api.Models.ItemVenda.Resposta;
using IteraDisc.Api.Models.Produtos.Resposta;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IteraDisc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemVendaController : Controller
    {
        private readonly IItemVendaAplicacao _itemVendaAplicacao;
        private readonly IVendaAplicacao _vendaAplicacao;

        public ItemVendaController(IItemVendaAplicacao itemVendaAplicacao, IVendaAplicacao vendaAplicacao)
        {
            _itemVendaAplicacao = itemVendaAplicacao;
            _vendaAplicacao = vendaAplicacao;
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
                    ValorItemVenda = itemVendaAtualizar.ValorItemVenda,
                    Vendido = itemVendaAtualizar.Vendido,
                    VendaId = itemVendaAtualizar.VendaId,
                    Venda = await _vendaAplicacao.Obter(itemVendaAtualizar.VendaId)
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
        public async Task<ActionResult> Obter([FromRoute] int itemVendaId, [FromQuery] bool vendido, [FromQuery] bool descartado)
        {
            try
            {
                var itemVendaDominio = await _itemVendaAplicacao.Obter(itemVendaId, vendido, descartado);

                var itemVenda = new ItemVendaResponse()
                {
                    ItemVendaId = itemVendaDominio.ItemVendaId,
                    ProdutoId = itemVendaDominio.ProdutoId,
                    Produto = new ProdutoResponseDTO
                        {
                          ProdutoId = itemVendaDominio.ProdutoId,
                          Nome = itemVendaDominio.Produto.Nome,
                          Descricao = itemVendaDominio.Produto.Descricao,
                          Preco = itemVendaDominio.Produto.Preco

                        }, 
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
        public async Task<ActionResult> List([FromQuery] bool vendido, [FromQuery] bool descartado)
        {
            try
            {
                var itemVendaDominio = await _itemVendaAplicacao.Listar(vendido, descartado);

                var itensVenda = itemVendaDominio.Select(iv => new ItemVendaResponse()
                {
                    ItemVendaId = iv.ItemVendaId,
                    ProdutoId = iv.ProdutoId,
                    Produto = new ProdutoResponseDTO
                        {
                          ProdutoId = iv.ProdutoId,
                          Nome = iv.Produto.Nome,
                          Descricao = iv.Produto.Descricao,
                          Preco = iv.Produto.Preco

                        }, 
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

        [HttpDelete]
        [Route("Deletar/{itemVendaId}")]
        public async Task<ActionResult> Deletar([FromRoute] int itemVendaId)
        {
            try
            {
                await _itemVendaAplicacao.Descartar(itemVendaId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}