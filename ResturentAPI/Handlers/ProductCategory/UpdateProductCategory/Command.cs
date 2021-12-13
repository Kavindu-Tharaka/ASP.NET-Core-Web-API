using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace ResturentAPI.Handlers.ProductCategory.UpdateProductCategory
{
    public class Command : IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument document { get; set; }
    }
}
