using MediatR;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Resturant;
using System.Threading;
using System.Threading.Tasks;

namespace ResturentAPI.Handlers.Resturant.UpdateResturant
{
    public class CommandHanlder : IRequestHandler<Command, Unit>
    {
        private readonly IResturantRepository resturantRepository;

        public CommandHanlder(IResturantRepository resturantRepository)
        {
            this.resturantRepository = resturantRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await resturantRepository.UpdateResturant(request.Id, request.document);

            return Unit.Value;
        }
    }
}
