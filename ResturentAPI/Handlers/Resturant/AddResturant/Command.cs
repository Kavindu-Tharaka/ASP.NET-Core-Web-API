using MediatR;

namespace ResturentAPI.Handlers.Resturant.AddResturant
{
    public class Command : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
