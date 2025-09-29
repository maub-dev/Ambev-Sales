using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem
{
    public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CancelSaleItemHandler
        /// </summary>
        /// <param name="saleService">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CancelSaleItemHandler(
            ISaleService saleService,
            IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CancelSaleItemCommand request
        /// </summary>
        /// <param name="request">The CancelSaleItem command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A boolean indicating if the cancelation was succesfull</returns>
        public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleItemValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _saleService.CancelItemAsync(request.SaleId, request.SaleItemId, cancellationToken);

            return new CancelSaleItemResult { Success = true };
        }
    }
}
