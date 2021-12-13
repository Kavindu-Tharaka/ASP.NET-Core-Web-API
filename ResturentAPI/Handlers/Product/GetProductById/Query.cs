using MediatR;
using ResturentAPI.Models;

namespace ResturentAPI.Handlers.Product.GetProductById
{
    public class Query : IRequest<ProductModel>
    {
        public int Id { get; set; }
    }
}
