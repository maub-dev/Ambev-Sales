using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts
{
    public class GetAllCartsProfile : Profile
    {
        public GetAllCartsProfile()
        {
            CreateMap<GetAllCartsRequest, GetAllCartsCommand>();
            CreateMap<GetAllCartsResult, GetAllCartsResponse>();
        }
    }
}
