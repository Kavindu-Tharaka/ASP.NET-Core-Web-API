using MediatR;
using ResturentAPI.Models;

namespace ResturentAPI.Handlers.Product.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int UnitsInStock { get; set; }
        public int ResturantId { get; set; }    //1 to M relationship
        public int ProductCategoryId { get; set; }  //1 to M relationship
    }
}
