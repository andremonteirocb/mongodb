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
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductServices productServices, 
            ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try
            {
                var result = _productServices.QueryAll();
                return Ok(result.ToList());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{key}")]
        public ActionResult<Product> Get([FromRoute] Guid key)
        {
            try
            {
                var result = _productServices.Query(key);
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, key);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<Product> Insert([FromBody] Product product)
        {
            try
            {
                _productServices.Insert(product);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, product);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public ActionResult<Product> Delete(Guid id)
        {
            try
            {
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