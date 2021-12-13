using MediatR;
using ResturentAPI.Repositories.Product;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Product.AddProduct
{
    public class CommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository productRepository;

        public CommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductModel()
            {
                Name = request.Name,
                Price = request.Price,
                UnitsInStock = request.UnitsInStock,
                ResturantId = request.ResturantId,
                ProductCategoryId = request.ProductCategoryId,
            };

            return await productRepository.AddProduct(product);

        }
    }
}
