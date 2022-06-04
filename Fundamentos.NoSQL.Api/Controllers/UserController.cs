using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Models;

namespace Fundamentos.NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserServices userServices, 
            ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                var result = _userServices.QueryAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute] Guid id)
        {
            try
            {
                var user = _userServices.GetById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserInputModel novoUsuario)
        {
            try
            {
                var user = new User(novoUsuario.Mail, novoUsuario.Name);

                _userServices.Insert(user);

                return Created("", user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, novoUsuario);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UserInputModel usuarioAtualizado)
        {
            try
            {
                var user = _userServices.GetById(id);
                if (user == null)
                    return NotFound();

                user.AtualizarUsuario(usuarioAtualizado.Mail, usuarioAtualizado.Name);

                _userServices.Update(id, user);

                return Ok(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public ActionResult<User> Delete(Guid id)
        {
            try
            {
                var user = _userServices.GetById(id);
                if (user == null)
                    return NotFound();

                _userServices.Delete(id);
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