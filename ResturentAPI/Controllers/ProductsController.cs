using MediatR;
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
        private readonly IMediator mediator;

        public ProductsController(IProductRepository productRepository, IMediator mediator)
        {
            this.productRepository = productRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //var products = await productRepository.GetAllProducts();

            var products = await mediator.Send(new Handlers.Product.GetAllProducts.Query());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            //var product = await productRepository.GetProductById(id);

            var product = await mediator.Send(new Handlers.Product.GetProductById.Query() { Id = id });

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Handlers.Product.AddProduct.AddProductCommand command)
        {
            //var id = await productRepository.AddProduct(productmodel);

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "products" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            //await productRepository.UpdateProduct(id, document);

            await mediator.Send(new Handlers.Product.UpdateProduct.Command() { Id = id, document = document });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //await productRepository.DeleteProduct(id);
            
            await mediator.Send(new Handlers.Product.DeleteProduct.Command() { Id = id });

            return Ok();
        }
    }
}
