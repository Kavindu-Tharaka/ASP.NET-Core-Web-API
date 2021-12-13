using MediatR;
using ResturentAPI.Repositories.ProductCategory;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.ProductCategory.AddProductCategory
{
    public class CommandHandler : IRequestHandler<AddProductCategoryCommand, int>
    {
        private readonly IProductCategoriesRepository productCategoriesRepository;

        public CommandHandler(IProductCategoriesRepository productCategoriesRepository)
        {
            this.productCategoriesRepository = productCategoriesRepository;
        }

        public async Task<int> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = new ProductCategoryModel()
            {
                CategoryName = request.CategoryName,
            };

            return await productCategoriesRepository.AddProductCategory(productCategory);

        }
    }
}
