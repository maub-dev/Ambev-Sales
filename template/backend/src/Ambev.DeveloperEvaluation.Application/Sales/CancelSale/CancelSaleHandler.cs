using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CancelSaleHandler
        /// </summary>
        /// <param name="saleService">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CancelSaleHandler(
            ISaleService saleService,
            IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CancelSaleCommand request
        /// </summary>
        /// <param name="request">The CancelSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A boolean indicating if the cancelation was succesfull</returns>
        public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _saleService.CancelAsync(request.Id, cancellationToken);

            return new CancelSaleResult { Success = true };
        }
    }
}
