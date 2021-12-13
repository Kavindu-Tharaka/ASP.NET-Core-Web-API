using MediatR;
using ResturentAPI.Repositories.ProductCategory;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.ProductCategory.DeleteProductCategory
{
    public class CommandHandler : IRequestHandler<Command, Unit>
    {
        private readonly IProductCategoriesRepository productCategoriesRepository;

        public CommandHandler(IProductCategoriesRepository productCategoriesRepository)
        {
            this.productCategoriesRepository = productCategoriesRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await productCategoriesRepository.DeleteProductCategory(request.Id);
            return Unit.Value;
        }
    }
}
