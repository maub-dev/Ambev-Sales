using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    /// <summary>
    /// Handler for processing GetAllProductsCommand requests
    /// </summary>
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, IQueryable<GetAllProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of GetUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetUserCommand</param>
        public GetAllProductsHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IConfigurationProvider configurationProvider)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        public async Task<IQueryable<GetAllProductsResult>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll();

            return await Task.FromResult(products.ProjectTo<GetAllProductsResult>(_configurationProvider));
        }
    }
}
