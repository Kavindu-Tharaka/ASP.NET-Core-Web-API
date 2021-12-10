using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers
{
    public class GetResturantById
    {
        public class Query : IRequest<ResturantModel> 
        {
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, ResturantModel>
        {
            private readonly IResturantRepository resturantRepository;

            public QueryHandler(IResturantRepository resturantRepository)
            {
                this.resturantRepository = resturantRepository;
            }

            public async Task<ResturantModel> Handle(Query request, CancellationToken cancellationToken)
            {
                return await resturantRepository.GetResturantById(request.Id);
            }
        }
    }
}
