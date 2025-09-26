using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetAllCategoriesHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetUserCommand</param>
        public GetAllCategoriesHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetAllCategoriesCommand request
        /// </summary>
        /// <param name="request">The GetAllCategories command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of product categories</returns>
        public async Task<GetAllCategoriesResult> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
            var categories = await _productRepository.GetAllCategoriesAsync(cancellationToken);

            return new GetAllCategoriesResult { Categories = categories };
        }
    }
}
