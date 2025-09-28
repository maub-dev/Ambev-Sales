using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateCartCommand request
        /// </summary>
        /// <param name="command">The UpdateCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated cart details</returns>
        public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCartValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if ((await _cartRepository.GetByIdAsync(request.Id, cancellationToken)) is null)
                throw new ValidationException([new ValidationFailure(nameof(request.Id), $"The Cart {request.Id} was not found.")]);

            var cart = _mapper.Map<Cart>(request);
            foreach (var item in cart.Products)
                item.CartId = request.Id;

            var createdCart = await _cartRepository.UpdateAsync(cart, cancellationToken);
            var result = _mapper.Map<UpdateCartResult>(createdCart);
            return result;
        }
    }
}
