using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    public class GetAllCartsHandler : IRequestHandler<GetAllCartsCommand, IQueryable<GetAllCartsResult>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of GetAllCartsHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetUserCommand</param>
        public GetAllCartsHandler(
            ICartRepository cartRepository,
            IMapper mapper,
            IConfigurationProvider configurationProvider)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        public async Task<IQueryable<GetAllCartsResult>> Handle(GetAllCartsCommand request, CancellationToken cancellationToken)
        {
            var products = _cartRepository.GetAll();

            return await Task.FromResult(products.ProjectTo<GetAllCartsResult>(_configurationProvider));
        }
    }
}
