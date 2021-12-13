using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Product;
using ResturentAPI.Repositories.Resturant;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Product.GetAllProducts
{
    public class QueryHandler : IRequestHandler<Query, List<ProductModel>>
    {
        private readonly IProductRepository productRepository;

        public QueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<ProductModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await productRepository.GetAllProducts();
        }
    }
}
