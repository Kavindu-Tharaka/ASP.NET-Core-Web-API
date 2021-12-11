using MediatR;

namespace ResturentAPI.Handlers.Resturant.DeleteResturant
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}
