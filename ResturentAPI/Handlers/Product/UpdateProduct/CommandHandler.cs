using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Product;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Product.UpdateProduct
{
    public class CommandHanlder : IRequestHandler<Command, Unit>
    {
        private readonly IProductRepository productRepository;

        public CommandHanlder(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await productRepository.UpdateProduct(request.Id, request.document);

            return Unit.Value;
        }
    }
}
