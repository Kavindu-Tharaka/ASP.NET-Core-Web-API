using MediatR;

namespace ResturentAPI.Handlers.ProductCategory.AddProductCategory
{
    public class AddProductCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
