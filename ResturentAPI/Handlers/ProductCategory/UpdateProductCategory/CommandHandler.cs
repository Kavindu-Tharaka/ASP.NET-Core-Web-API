using MediatR;
using ResturentAPI.Repositories.ProductCategory;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.ProductCategory.UpdateProductCategory
{
    public class CommandHanlder : IRequestHandler<Command, Unit>
    {
        private readonly IProductCategoriesRepository productCategoriesRepository;

        public CommandHanlder(IProductCategoriesRepository productCategoriesRepository)
        {
            this.productCategoriesRepository = productCategoriesRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await productCategoriesRepository.UpdateProductCategory(request.Id, request.document);

            return Unit.Value;
        }
    }
}
