using Microsoft.AspNetCore.JsonPatch;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<Handlers.Product.GetAllProducts.ProductModel>> GetAllProducts();
        Task<Handlers.Product.GetProductById.ProductModel> GetProductById(int id);
        Task<int> AddProduct(Handlers.Product.AddProduct.ProductModel productModel);
        Task UpdateProduct(int productId, JsonPatchDocument document);
        Task DeleteProduct(int productId);
    }
}
