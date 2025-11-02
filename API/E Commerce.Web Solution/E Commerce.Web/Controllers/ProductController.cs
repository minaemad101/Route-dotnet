using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            // mvc: url/product/get/id
            // api: get: url/api/product/id
            return new Product() { Id = id, Name = "Test" };
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() => new List<Product>();

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product) 
        {
            return product;
        }
        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return product;
        }
        [HttpDelete]
        public ActionResult<Product> DeleteProduct(Product product)
        {
            return product;
        }

    }
}
