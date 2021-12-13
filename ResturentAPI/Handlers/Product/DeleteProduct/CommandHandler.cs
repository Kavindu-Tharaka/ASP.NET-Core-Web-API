using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Product;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Product.DeleteProduct
{
    public class CommandHandler : IRequestHandler<Command, Unit>
    {
        private readonly IProductRepository productRepository;

        public CommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await productRepository.DeleteProduct(request.Id);
            return Unit.Value;
        }
    }
}
