using MediatR;

namespace ResturentAPI.Handlers.Product.DeleteProduct
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}
