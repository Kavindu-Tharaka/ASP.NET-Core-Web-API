using Microsoft.AspNetCore.JsonPatch;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        Task<int> AddProduct(ProductModel productModel);
        Task UpdateProduct(int productId, JsonPatchDocument document);
        Task DeleteProduct(int productId);
    }
}
