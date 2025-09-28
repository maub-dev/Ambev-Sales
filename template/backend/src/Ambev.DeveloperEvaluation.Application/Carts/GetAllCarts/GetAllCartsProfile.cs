using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    public class GetAllCartsProfile : Profile
    {
        public GetAllCartsProfile()
        {
            CreateMap<Cart, GetAllCartsResult>();
        }
    }
}
