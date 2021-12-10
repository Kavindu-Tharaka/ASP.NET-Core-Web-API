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

        public ProductCategoriesController(IProductCategoriesRepository productCategoriesRepository)
        {
            this.productCategoriesRepository = productCategoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var productCategories = await productCategoriesRepository.GetAllProductCategories();
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategoryById([FromRoute] int id)
        {
            var productCategory = await productCategoriesRepository.GetProductCategoryById(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategoryModel productCategorymodel)
        {
            var id = await productCategoriesRepository.AddProductCategory(productCategorymodel);
            return CreatedAtAction(nameof(GetProductCategoryById), new { id = id, controller = "ProductCategories" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            await productCategoriesRepository.UpdateProductCategory(id, document);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productCategoriesRepository.DeleteProductCategory(id);
            return Ok();
        }
    }
}
