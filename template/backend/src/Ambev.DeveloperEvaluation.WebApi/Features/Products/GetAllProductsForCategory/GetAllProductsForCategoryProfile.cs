using Ambev.DeveloperEvaluation.Application.Products.GetAllProductsForCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductsForCategory
{
    public class GetAllProductsForCategoryProfile : Profile
    {
        public GetAllProductsForCategoryProfile()
        {
            CreateMap<GetAllProductsForCategoryRequest, GetAllProductsForCategoryCommand>();
            CreateMap<GetAllProductsForCategoryResult, GetAllProductsForCategoryResponse>();
        }
    }
}
