using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile()
        {
            //CreateMap<GetAllProductsCommand, Product>();
            CreateMap<Product, GetAllProductsResult>();
        }
    }
}
