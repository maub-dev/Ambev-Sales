using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateProductCommand request
        /// </summary>
        /// <param name="command">The UpdateProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated user details</returns>
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if ((await _productRepository.GetByIdAsync(request.Id, cancellationToken)) is null)
                throw new ValidationException([new ValidationFailure(nameof(request.Id), $"The Product {request.Id} was not found.")]);

            var product = _mapper.Map<Product>(request);

            var createdProduct = await _productRepository.UpdateAsync(product, cancellationToken);
            var result = _mapper.Map<UpdateProductResult>(createdProduct);
            return result;
        }
    }
}
