using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;

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
                return Ok(result.ToList());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{key}")]
        public ActionResult<User> Get([FromRoute] Guid key)
        {
            try
            {
                var result = _userServices.Query(key);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, key);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<User> Insert([FromBody] User user)
        {
            try
            {
                _userServices.Insert(user);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, user);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public ActionResult<User> Delete(Guid id)
        {
            try
            {
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