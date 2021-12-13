using MediatR;
using ResturentAPI.Models;
using System.Collections.Generic;

namespace ResturentAPI.Handlers.Product.GetAllProducts
{
    public class Query : IRequest<List<ProductModel>> { }
}
