using AutoMapper;
using ResturentAPI.Data;
using ResturentAPI.Models;

namespace BookStoreAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {

            CreateMap<Product, ResturentAPI.Handlers.Product.AddProduct.ProductModel>().ReverseMap();
            CreateMap<Product, ResturentAPI.Handlers.Product.GetAllProducts.ProductModel>().ReverseMap();
            CreateMap<Product, ResturentAPI.Handlers.Product.GetProductById.ProductModel>().ReverseMap();


            CreateMap<ProductCategory, ResturentAPI.Handlers.ProductCategory.AddProductCategory.ProductCategoryModel>().ReverseMap();
            CreateMap<ProductCategory, ResturentAPI.Handlers.ProductCategory.GetAllProductCategories.ProductCategoryModel>().ReverseMap();
            CreateMap<ProductCategory, ResturentAPI.Handlers.ProductCategory.GetProductCategoryById.ProductCategoryModel>().ReverseMap();


            CreateMap<Resturant, ResturentAPI.Handlers.Resturant.AddResturant.ResturantModel>().ReverseMap();
            CreateMap<Resturant, ResturentAPI.Handlers.Resturant.GetAllResturants.ResturantModel>().ReverseMap();
            CreateMap<Resturant, ResturentAPI.Handlers.Resturant.GetResturantById.ResturantModel>().ReverseMap();


        }
    }
}
