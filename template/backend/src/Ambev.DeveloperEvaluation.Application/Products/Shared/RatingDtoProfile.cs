using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.Shared
{
    public class RatingDtoProfile : Profile
    {
        public RatingDtoProfile()
        {
            CreateMap<RatingDto, Rating>().ReverseMap();
        }
    }
}
