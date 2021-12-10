using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using ResturentAPI.Data;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ResturentAPI.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ResturantStoreContext context;
        private readonly IMapper mapper;

        public ProductRepository(ResturantStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async  Task<int> AddProduct(ProductModel productModel)
        {
            var product = mapper.Map<Data.Product>(productModel);   //mehema harida?

            /*var product2 = new Products()
            {
                Name = productModel.Name,
                Address = productModel.Address,
                Price = productModel.Price,
                UnitsInStock = productModel.UnitsInStock,
                ResturantId = productModel.ResturantId,                 //??
                ProductCategoryId = productModel.ProductCategoryId      //??
            };*/

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return product.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = new Data.Product() { Id = productId };
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            //GET karanna yaddi error ekak enawa Include dapu nisa

            var records = await context.Products.Include(product => product.Resturant)
                                                .Include(product => product.ProductCategory).ToListAsync();

            //var records = await context.Products.ToListAsync();

            return mapper.Map<List<ProductModel>>(records);
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            //GET karanna yaddi error ekak enawa Include dapu nisa

            var product = await context.Products.Include(product => product.Resturant)
                                                .Include(product => product.ProductCategory).FirstOrDefaultAsync(p => p.Id.Equals(id));

            //var product = await context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

            return mapper.Map<ProductModel>(product);
        }

        public async Task UpdateProduct(int productId, JsonPatchDocument document)
        {
            var product = await context.Products.FindAsync(productId);
            if (product != null)
            {
                document.ApplyTo(product);
                await context.SaveChangesAsync();
            }
        }
    }
}
