using MediatR;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers
{
    public class DeleteResturant
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly IResturantRepository resturantRepository;

            public CommandHandler(IResturantRepository resturantRepository)
            {
                this.resturantRepository = resturantRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await resturantRepository.DeleteResturant(request.Id);
                return Unit.Value;
            }
        }
    }
}
