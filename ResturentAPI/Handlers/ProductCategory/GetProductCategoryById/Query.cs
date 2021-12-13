using MediatR;
using ResturentAPI.Models;

namespace ResturentAPI.Handlers.ProductCategory.GetProductCategoryById
{
    public class Query : IRequest<ProductCategoryModel>
    {
        public int Id { get; set; }
    }
}
