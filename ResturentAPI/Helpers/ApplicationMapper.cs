using AutoMapper;
using ResturentAPI.Data;
using ResturentAPI.Models;

namespace BookStoreAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryModel>().ReverseMap();
            CreateMap<Resturant, ResturantModel>().ReverseMap();

        }
    }
}
