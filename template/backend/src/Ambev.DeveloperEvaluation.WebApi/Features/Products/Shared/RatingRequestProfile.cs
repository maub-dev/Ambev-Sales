using Ambev.DeveloperEvaluation.Application.Products.Shared;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Shared
{
    /// <summary>
    /// Profile for mapping between Application and API CreateProduct Rating objects
    /// </summary>
    public class RatingRequestProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduct feature
        /// </summary>
        public RatingRequestProfile()
        {
            CreateMap<RatingRequest, RatingDto>().ReverseMap();
            CreateMap<RatingResponse, RatingDto>().ReverseMap();
        }
    }
}
