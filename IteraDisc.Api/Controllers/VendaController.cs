using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Api.Models.ItemVenda.Resposta;
using IteraDisc.Api.Models.Produtos.Resposta;
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
        public async Task<ActionResult<int>> Criar([FromBody] VendaCriar request)
        {
            try
            {
                var vendaId = await _vendaAplicacao.Criar(
                    request.UsuarioId,
                    request.Itens
                );

                return Ok(vendaId);
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
                    Itens = vendaDominio.Itens.Select(i => new ItemVendaResponse()
                    {
                        ItemVendaId = i.ItemVendaId,
                        ProdutoId = i.ProdutoId,
                        Produto = new ProdutoResponseDTO
                        {
                          ProdutoId = i.ProdutoId,
                          Nome = i.Produto.Nome,
                          Descricao = i.Produto.Descricao,
                          Preco = i.Produto.Preco

                        },
                        Quantidade = i.Quantidade,
                        ValorItemVenda = i.ValorItemVenda,
                        Vendido = i.Vendido,
                        VendaId = i.VendaId
                    }).ToList()
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
        public async Task<ActionResult> Listar([FromRoute] Venda venda)
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
                    Itens = v.Itens.Select(i => new ItemVendaResponse()
                    {
                        ItemVendaId = i.ItemVendaId,
                        ProdutoId = i.ProdutoId,
                        Produto = new ProdutoResponseDTO
                        {
                          ProdutoId = i.ProdutoId,
                          Nome = i.Produto.Nome,
                          Descricao = i.Produto.Descricao,
                          Preco = i.Produto.Preco

                        },
                        Quantidade = i.Quantidade,
                        ValorItemVenda = i.ValorItemVenda,
                        Vendido = i.Vendido,
                        VendaId = i.VendaId
                    }).ToList()
                }).ToList();

                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("HistoricoCliente")]
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
                    Itens = v.Itens.Select(i => new ItemVendaResponse()
                    {
                        ItemVendaId = i.ItemVendaId,
                        ProdutoId = i.ProdutoId,
                        Produto = new ProdutoResponseDTO
                        {
                          ProdutoId = i.ProdutoId,
                          Nome = i.Produto.Nome,
                          Descricao = i.Produto.Descricao,
                          Preco = i.Produto.Preco

                        },
                        Quantidade = i.Quantidade,
                        ValorItemVenda = i.ValorItemVenda,
                        Vendido = i.Vendido,
                        VendaId = i.VendaId
                    }).ToList()
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