using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using WebApi.Data;
using WebApi.Repositories.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepos;
        public ProductsController(IProductRepository productRepos)
        {
            _productRepos = productRepos;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepos.GetProducts();
            return Ok(products);
        }
    }
}
