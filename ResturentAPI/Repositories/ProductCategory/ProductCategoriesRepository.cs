using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ResturentAPI.Data;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.ProductCategory
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly ResturantStoreContext context;
        private readonly IMapper mapper;

        public ProductCategoriesRepository(ResturantStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddProductCategory(Handlers.ProductCategory.AddProductCategory.ProductCategoryModel productCategoryModel)
        {
            var productCategory = mapper.Map<Data.ProductCategory>(productCategoryModel);   //mehema harida?  //swagger walin test karaddi add nam una

            context.ProductCategories.Add(productCategory);
            await context.SaveChangesAsync();

            return productCategory.Id;
        }

        public async Task DeleteProductCategory(int productCategoryId)
        {
            var productCategory = new Data.ProductCategory() { Id = productCategoryId };
            context.ProductCategories.Remove(productCategory);
            await context.SaveChangesAsync();
        }

        public async Task<List<Handlers.ProductCategory.GetAllProductCategories.ProductCategoryModel>> GetAllProductCategories()
        {
            var records = await context.ProductCategories.Include(productCategory => productCategory.Products).ToListAsync();

            return mapper.Map<List<Handlers.ProductCategory.GetAllProductCategories.ProductCategoryModel>>(records);
        }

        public async Task<Handlers.ProductCategory.GetProductCategoryById.ProductCategoryModel> GetProductCategoryById(int id)
        {
            var productCategory = await context.ProductCategories.Include(productCategory => productCategory.Products).FirstOrDefaultAsync(pc => pc.Id.Equals(id));
            return mapper.Map<Handlers.ProductCategory.GetProductCategoryById.ProductCategoryModel>(productCategory);
        }

        public async Task UpdateProductCategory(int productCategoryId, JsonPatchDocument document)
        {
            var productCategory = await context.ProductCategories.FindAsync(productCategoryId);
            if (productCategory != null)
            {
                document.ApplyTo(productCategory);
                await context.SaveChangesAsync();
            }
        }
    }
}
