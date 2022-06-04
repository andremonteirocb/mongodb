using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Models;

namespace Fundamentos.NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServices _productServices;
        private readonly ILogger<ProdutoController> _logger;
        public ProdutoController(IProdutoServices productServices, 
            ILogger<ProdutoController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            try
            {
                var result = _productServices.QueryAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get([FromRoute] Guid id)
        {
            try
            {
                var product = _productServices.GetById(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoInputModel novoProduto)
        {
            try
            {
                var produto = new Produto(novoProduto.Name, novoProduto.Description);

                _productServices.Insert(produto);

                return Created("", produto);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, novoProduto);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoInputModel produtoAtualizado)
        {
            try
            {
                var produto = _productServices.GetById(id);
                if (produto == null)
                    return NotFound();

                produto.AtualizarProduto(produtoAtualizado.Name, produtoAtualizado.Description);

                _productServices.Update(id, produto);

                return Ok(produto);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public ActionResult<Produto> Delete(Guid id)
        {
            try
            {
                var product = _productServices.GetById(id);
                if (product == null)
                    return NotFound();

                _productServices.Delete(id);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }
    }
}