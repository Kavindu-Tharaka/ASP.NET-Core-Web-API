using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Product;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Product.GetProductById
{
    public class QueryHandler : IRequestHandler<Query, ProductModel>
    {
        private readonly IProductRepository productRepository;

        public QueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductModel> Handle(Query request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductById(request.Id);
        }
    }
}
