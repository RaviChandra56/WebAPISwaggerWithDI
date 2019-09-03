using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _productRepository;
        public ProductsController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productRepository.GetProducts());
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_productRepository.GetProduct(id));
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)

            {
                return BadRequest();
            }

            try
            {
                _productRepository.UpdateProduct(product);
            }
            catch (Exception)
            {
                return NotFound("No record found against this Id....");
            }

            return Ok("Product Updated...");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok("Product Deleted....");
        }
    }
}
