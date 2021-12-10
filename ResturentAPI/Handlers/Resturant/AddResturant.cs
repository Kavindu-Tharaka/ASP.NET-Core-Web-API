using MediatR;
using ResturentAPI.Data;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers
{
    public class AddResturant
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly IResturantRepository resturantRepository;

            public CommandHandler(IResturantRepository resturantRepository)
            {
                this.resturantRepository = resturantRepository;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var resturant = new ResturantModel()
                {
                    Name = request.Name,
                    Address = request.Address,
                };

                return await resturantRepository.AddResturant(resturant);
                
            }
        }
    }
}
