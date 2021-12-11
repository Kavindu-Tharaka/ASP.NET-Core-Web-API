using MediatR;
using ResturentAPI.Models;

namespace ResturentAPI.Handlers.Resturant.GetResturantById
{
    public class Query : IRequest<ResturantModel>
    {
        public int Id { get; set; }
    }
}
