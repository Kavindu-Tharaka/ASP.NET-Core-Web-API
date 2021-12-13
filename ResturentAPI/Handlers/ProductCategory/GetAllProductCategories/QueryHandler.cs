using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.ProductCategory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.ProductCategory.GetAllProductCategories
{
    public class QueryHandler : IRequestHandler<Query, List<ProductCategoryModel>>
    {
        private readonly IProductCategoriesRepository productCategoriesRepository;

        public QueryHandler(IProductCategoriesRepository productCategoriesRepository)
        {
            this.productCategoriesRepository = productCategoriesRepository;
        }

        public async Task<List<ProductCategoryModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await productCategoriesRepository.GetAllProductCategories();
        }
    }
}
