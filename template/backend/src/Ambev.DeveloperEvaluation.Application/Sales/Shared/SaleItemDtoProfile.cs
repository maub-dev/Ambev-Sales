using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Shared
{
    public class SaleItemDtoProfile : Profile
    {
        public SaleItemDtoProfile()
        {
            CreateMap<SaleItemDto, SaleItem>().ReverseMap();
        }
    }
}
