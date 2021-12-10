using Microsoft.AspNetCore.JsonPatch;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.ProductCategory
{
    public interface IProductCategoriesRepository
    {
        Task<List<ProductCategoryModel>> GetAllProductCategories();
        Task<ProductCategoryModel> GetProductCategoryById(int id);
        Task<int> AddProductCategory(ProductCategoryModel productCategoryModel);
        Task UpdateProductCategory(int productCategoryId, JsonPatchDocument document);
        Task DeleteProductCategory(int productCategoryId);
    }
}
