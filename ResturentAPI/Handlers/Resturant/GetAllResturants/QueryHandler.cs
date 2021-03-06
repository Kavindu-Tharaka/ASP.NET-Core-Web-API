using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Resturant;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Resturant.GetAllResturants
{
    public class QueryHandler : IRequestHandler<Query, List<ResturantModel>>
    {
        private readonly IResturantRepository resturantRepository;

        public QueryHandler(IResturantRepository resturantRepository)
        {
            this.resturantRepository = resturantRepository;
        }

        public async Task<List<ResturantModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await resturantRepository.GetAllResturants();
        }
    }
}
