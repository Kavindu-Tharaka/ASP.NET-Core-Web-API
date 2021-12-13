using Microsoft.AspNetCore.JsonPatch;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.ProductCategory
{
    public interface IProductCategoriesRepository
    {
        Task<List<Handlers.ProductCategory.GetAllProductCategories.ProductCategoryModel>> GetAllProductCategories();
        Task<Handlers.ProductCategory.GetProductCategoryById.ProductCategoryModel> GetProductCategoryById(int id);
        Task<int> AddProductCategory(Handlers.ProductCategory.AddProductCategory.ProductCategoryModel productCategoryModel);
        Task UpdateProductCategory(int productCategoryId, JsonPatchDocument document);
        Task DeleteProductCategory(int productCategoryId);
    }
}
