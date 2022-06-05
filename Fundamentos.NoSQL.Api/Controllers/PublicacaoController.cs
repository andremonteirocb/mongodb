using Microsoft.AspNetCore.Mvc;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Models;
using Fundamentos.NoSQL.Domain.Entities;
using System;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace Fundamentos.NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        private IPublicacaoServices _publicacaoServices;
        private readonly ILogger<PublicacaoController> _logger;
        public PublicacaoController(IPublicacaoServices publicacaoServices,
            ILogger<PublicacaoController> logger)
        {
            _publicacaoServices = publicacaoServices;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Publicacao>), StatusCodes.Status200OK)]
        public IActionResult Get(int? limit)
        {
            try
            {
                var publicacoes = _publicacaoServices.QueryAll(limit);
                return Ok(publicacoes);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Publicacao), StatusCodes.Status200OK)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var publicacao = _publicacaoServices.GetById(id);
                if (publicacao == null)
                    return NotFound();

                return Ok(publicacao);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Publicacao), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] PublicacaoInputModel novaPublicacao)
        {
            try
            {
                var publicacao = new Publicacao(novaPublicacao.Nome, novaPublicacao.Description);
                if (novaPublicacao.Autores.Any())
                    novaPublicacao.Autores.ForEach(a => publicacao.AdicionarAutor(a));

                _publicacaoServices.Insert(publicacao);

                return Created("", publicacao);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Publicacao), StatusCodes.Status200OK)]
        public IActionResult Put(Guid id, [FromBody] PublicacaoInputModel novaPublicacao)
        {
            try
            {
                var publicacao = _publicacaoServices.GetById(id);
                if (publicacao == null)
                    return NotFound();

                publicacao.AtualizarPublicacao(novaPublicacao.Nome, novaPublicacao.Description);
                _publicacaoServices.Replace(id, publicacao);

                return Ok(publicacao);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var publicacao = _publicacaoServices.GetById(id);
                if (publicacao == null)
                    return NotFound();

                _publicacaoServices.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("addComment/{publicacaoId}")]
        [ProducesResponseType(typeof(Comentario), StatusCodes.Status201Created)]
        public IActionResult AdicionarComentario(Guid publicacaoId, [FromBody] ComentarioInputModel novoComentario)
        {
            try
            {
                var comentario = _publicacaoServices.AdicionarComentario(publicacaoId, novoComentario.Nome, novoComentario.Conteudo);
                return Created("", comentario);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("removeComment/{publicacaoId}/{comentarioId}")]
        public IActionResult RemoverComentario(Guid publicacaoId, Guid comentarioId)
        {
            try
            {
                _publicacaoServices.RemoverComentario(publicacaoId, comentarioId);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        private void Builders()
        {
            //builders
            var filter = Builders<Publicacao>.Filter.Eq(x => x.Name, "") & 
                Builders<Publicacao>.Filter.Eq(x => x.Name, "");

            var sortDefinition = Builders<Publicacao>.Sort.Descending(x => x.Name)
                .Descending(x => x.Description);
        }
    }
}
