using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace ResturentAPI.Handlers.Product.UpdateProduct
{
    public class Command : IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument document { get; set; }
    }
}
