using Ambev.DeveloperEvaluation.Application.Sales.Shared;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Shared
{
    public class SaleItemRequestProfile : Profile
    {
        public SaleItemRequestProfile()
        {
            CreateMap<SaleItemRequest, SaleItemDto>().ReverseMap();
            CreateMap<SaleItemResponse, SaleItemDto>().ReverseMap();
        }
    }
}
