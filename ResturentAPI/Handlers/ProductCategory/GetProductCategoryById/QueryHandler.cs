using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.ProductCategory;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.ProductCategory.GetProductCategoryById
{
    public class QueryHandler : IRequestHandler<Query, ProductCategoryModel>
    {
        private readonly IProductCategoriesRepository productCategoriesRepository;

        public QueryHandler(IProductCategoriesRepository productCategoriesRepository)
        {
            this.productCategoriesRepository = productCategoriesRepository;
        }

        public async Task<ProductCategoryModel> Handle(Query request, CancellationToken cancellationToken)
        {
            return await productCategoriesRepository.GetProductCategoryById(request.Id);
        }
    }
}
