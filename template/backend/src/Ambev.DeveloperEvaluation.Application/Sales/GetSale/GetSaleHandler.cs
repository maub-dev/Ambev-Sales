using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of GetSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetSaleHandler(
            ISaleRepository saleRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<GetSaleResult>(sale);
        }
    }
}
