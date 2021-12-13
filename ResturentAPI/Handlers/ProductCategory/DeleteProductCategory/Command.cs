using MediatR;

namespace ResturentAPI.Handlers.ProductCategory.DeleteProductCategory
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}
