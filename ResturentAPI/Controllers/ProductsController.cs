using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Product;
using System.Threading.Tasks;

namespace ResturentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel productmodel)
        {
            var id = await productRepository.AddProduct(productmodel);
            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "products" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            await productRepository.UpdateProduct(id, document);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productRepository.DeleteProduct(id);
            return Ok();
        }
    }
}
