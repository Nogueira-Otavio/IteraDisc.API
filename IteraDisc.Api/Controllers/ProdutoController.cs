using IteraDisc.Api.Models.Produtos.Requisicao;
using IteraDisc.Api.Models.Produtos.Resposta;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Dominio.DTOs;
using IteraDisc.Dominio.Entidades;
using IteraDisc.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IteraDisc.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAplicao _produtoAplicao;
        private readonly IDapperProdutoRepositorio _dapperProdutoRepositorio;

        public ProdutoController(
            IProdutoAplicao produtoAplicao,
            IDapperProdutoRepositorio dapperProdutoRepositorio)
        {
            _produtoAplicao = produtoAplicao;
            _dapperProdutoRepositorio = dapperProdutoRepositorio;
        }

        [HttpPost]
        [Route("Criar")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Criar([FromBody] ProdutoCriar produtoCriar)
        {
            try
            {
                var produtoDominio = new Produto()
                {
                    Nome = produtoCriar.Nome,
                    Descricao = produtoCriar.Descricao,
                    Preco = produtoCriar.Preco,
                    EmEstoque = produtoCriar.EmEstoque
                };

                var produtoID = await _produtoAplicao.Criar(produtoDominio);
                return Ok(produtoID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Atualizar([FromBody] ProdutoAtualizar produtoAtualizar)
        {
            try
            {
                var produtoDominio = new Produto()
                {
                    ProdutoId = produtoAtualizar.ProdutoId,
                    Nome = produtoAtualizar.Nome,
                    Descricao = produtoAtualizar.Descricao,
                    Preco = produtoAtualizar.Preco,
                    EmEstoque = produtoAtualizar.EmEstoque
                };

                await _produtoAplicao.Atualizar(produtoDominio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{produtoId}")]
        public async Task<ActionResult> Obter([FromRoute] int produtoId)
        {
            try
            {
                var produtoDominio = await _produtoAplicao.Obter(produtoId);

                var produto = new ProdutoResponse()
                {
                    ProdutoId = produtoDominio.ProdutoId,
                    Nome = produtoDominio.Nome,
                    Descricao = produtoDominio.Descricao,
                    Preco = produtoDominio.Preco,
                    EmEstoque = produtoDominio.EmEstoque
                };

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{produtoId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Deletar([FromRoute] int produtoId)
        {
            try
            {
                await _produtoAplicao.Deletar(produtoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Restaurar/{produtoId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Restaurar([FromRoute] int produtoId)
        {
            try
            {
                await _produtoAplicao.Restaurar(produtoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar([FromQuery] bool ativos)
        {
            try
            {
                var produtoDominio = await _produtoAplicao.Listar(ativos);

                var produtos = produtoDominio.Select(p => new ProdutoResponse()
                {
                    ProdutoId = p.ProdutoId,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    EmEstoque = p.EmEstoque
                }).ToList();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("EstoqueBaixo")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EstoqueBaixo([FromQuery] int limite = 5)
        {
            try
            {
                var resultado = await _dapperProdutoRepositorio.ProdutosEstoqueBaixo(limite);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}