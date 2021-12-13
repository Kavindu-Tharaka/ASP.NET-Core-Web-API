using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ResturentAPI.Models;
using ResturentAPI.Repositories.ProductCategory;
using System.Threading.Tasks;

namespace ResturentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesRepository productCategoriesRepository;
        private readonly IMediator mediator;

        public ProductCategoriesController(IProductCategoriesRepository productCategoriesRepository, IMediator mediator)
        {
            this.productCategoriesRepository = productCategoriesRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            //var productCategories = await productCategoriesRepository.GetAllProductCategories();

            var productCategories = await mediator.Send(new Handlers.ProductCategory.GetAllProductCategories.Query());
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategoryById([FromRoute] int id)
        {
            //var productCategory = await productCategoriesRepository.GetProductCategoryById(id);

            var productCategory = await mediator.Send(new Handlers.ProductCategory.GetProductCategoryById.Query() { Id = id });

            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory([FromBody] Handlers.ProductCategory.AddProductCategory.AddProductCategoryCommand command)
        {
            //var id = await productCategoriesRepository.AddProductCategory(productCategorymodel);

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetProductCategoryById), new { id = id, controller = "ProductCategories" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductCategory([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            //await productCategoriesRepository.UpdateProductCategory(id, document);
            
            await mediator.Send(new Handlers.ProductCategory.UpdateProductCategory.Command { Id = id, document = document });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            //await productCategoriesRepository.DeleteProductCategory(id);
            
            await mediator.Send(new Handlers.ProductCategory.DeleteProductCategory.Command() { Id = id });

            return Ok();
        }
    }
}
