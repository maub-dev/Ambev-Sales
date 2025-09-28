using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.Shared
{
    public class CartItemDtoProfile : Profile
    {
        public CartItemDtoProfile()
        {
            CreateMap<CartItemDto, CartItem>().ReverseMap();
        }
    }
}
