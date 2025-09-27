using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductsForCategory
{
    public class GetAllProductsForCategoryProfile : Profile
    {
        public GetAllProductsForCategoryProfile()
        {
            CreateMap<Product, GetAllProductsForCategoryResult>();
        }
    }
}
