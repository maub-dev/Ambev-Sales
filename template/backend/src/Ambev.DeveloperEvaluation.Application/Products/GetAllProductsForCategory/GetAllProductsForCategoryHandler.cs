using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductsForCategory
{
    /// <summary>
    /// Handler for processing GetAllProductsForCategoryCommand requests
    /// </summary>
    public class GetAllProductsForCategoryHandler : IRequestHandler<GetAllProductsForCategoryCommand, IQueryable<GetAllProductsForCategoryResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of GetAllProductsForCategoryHandler
        /// </summary>
        /// <param name="productRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetAllProductsForCategoryCommand</param>
        public GetAllProductsForCategoryHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IConfigurationProvider configurationProvider)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        public async Task<IQueryable<GetAllProductsForCategoryResult>> Handle(GetAllProductsForCategoryCommand request, CancellationToken cancellationToken)
        {

            var products = _productRepository.Find(x => x.Category == request.Category);

            return await Task.FromResult(products.ProjectTo<GetAllProductsForCategoryResult>(_configurationProvider));
        }
    }
}
