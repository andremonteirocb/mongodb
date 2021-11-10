using Microsoft.AspNetCore.Mvc;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Models;
using Fundamentos.NoSQL.Domain.Entities;
using System;
using Microsoft.Extensions.Logging;

namespace Fundamentos.NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private ITarefaServices _tarefasService;
        private readonly ILogger<TarefasController> _logger;
        public TarefasController(ITarefaServices tarefasService,
            ILogger<TarefasController> logger)
        {
            _tarefasService = tarefasService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tarefas = _tarefasService.QueryAll();
                return Ok(tarefas);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var tarefa = _tarefasService.Query(id);
                if (tarefa == null)
                    return NotFound();

                return Ok(tarefa);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TarefaInputModel novaTarefa)
        {
            try
            {
                var tarefa = new Tarefa(novaTarefa.Nome, novaTarefa.Detalhes);

                _tarefasService.Insert(tarefa);

                return Created("", tarefa);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TarefaInputModel tarefaAtualizada)
        {
            try
            {
                var tarefa = _tarefasService.Query(id);

                if (tarefa == null)
                    return NotFound();

                tarefa.AtualizarTarefa(tarefaAtualizada.Nome, tarefaAtualizada.Detalhes, tarefaAtualizada.Concluido);

                _tarefasService.Update(id, tarefa);

                return Ok(tarefa);
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
                var tarefa = _tarefasService.Query(id);
                if (tarefa == null)
                    return NotFound();

                _tarefasService.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
