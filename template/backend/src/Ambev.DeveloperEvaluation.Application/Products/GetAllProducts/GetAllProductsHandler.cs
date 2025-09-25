using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    /// <summary>
    /// Handler for processing GetAllProductsCommand requests
    /// </summary>
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, IEnumerable<GetAllProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetUserCommand</param>
        public GetAllProductsHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProductsResult>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<GetAllProductsResult>>(products);
        }
    }
}
