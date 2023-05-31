using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Caching.Memory;

using System.Net;

using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepos;
        private IMemoryCache _memoryCache;
        public ProductsController(IProductRepository productRepos, IMemoryCache memoryCache)
        {
            _productRepos = productRepos;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            if (!_memoryCache.TryGetValue("Products", out List<Product> cacheValue))
            {
                cacheValue = _productRepos.GetProducts();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                _memoryCache.Set("Products", cacheValue, cacheEntryOptions);
                return Ok(cacheValue);
            }
            var products = _memoryCache.Get("Products");
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var result = _productRepos.CreateProduct(product);
            if (!result) return BadRequest();
            return Created("Created ...", product);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _productRepos.DeleteProduct(id);
            if (!result) return BadRequest();
            return StatusCode(StatusCodes.Status204NoContent, "Product is deleted ...");
        }
    }
}
