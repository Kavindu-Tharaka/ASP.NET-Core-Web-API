using MediatR;
using ResturentAPI.Models;
using System.Collections.Generic;

namespace ResturentAPI.Handlers.ProductCategory.GetAllProductCategories
{
    public class Query : IRequest<List<ProductCategoryModel>> { }
}
