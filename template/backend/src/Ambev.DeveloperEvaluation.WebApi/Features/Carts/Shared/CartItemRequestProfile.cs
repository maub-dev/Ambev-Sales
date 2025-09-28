using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.Shared
{
    public class CartItemRequestProfile : Profile
    {
        public CartItemRequestProfile()
        {
            CreateMap<CartItemRequest, CartItemDto>().ReverseMap();
            CreateMap<CartItemResponse, CartItemDto>().ReverseMap();
        }
    }
}
