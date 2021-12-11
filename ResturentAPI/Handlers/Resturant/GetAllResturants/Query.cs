using MediatR;
using ResturentAPI.Models;
using System.Collections.Generic;

namespace ResturentAPI.Handlers.Resturant.GetAllResturants
{
    public class Query : IRequest<List<ResturantModel>> { }
}
