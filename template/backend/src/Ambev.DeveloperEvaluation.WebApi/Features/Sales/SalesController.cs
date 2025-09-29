using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.QueryableExtensions;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    /// <summary>
    /// Controller for managing sales operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of SalesController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="configurationProvider">The AutoMapper configuration provider</param>
        public SalesController(IMediator mediator, IMapper mapper, AutoMapper.IConfigurationProvider configurationProvider)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        /// <summary>
        /// Gets the list of sales
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of sales</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<GetAllSalesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSalesRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetAllSalesRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetAllSalesCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = response.ProjectTo<GetAllSalesResponse>(_configurationProvider);

            return OkPaginated(await PaginatedList<GetAllSalesResponse>.CreateAsync(data, request.Page, request.Size));
        }

        /// <summary>
        /// Gets a sale by ID
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale filtered by ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetSaleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetSaleRequest { Id = id };
            var validator = new GetSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<GetSaleResponse>(response));
        }

        /// <summary>
        /// Creates a new sale
        /// </summary>
        /// <param name="request">The sale creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(response)
            });
        }

        /// <summary>
        /// Updates a sale
        /// </summary>
        /// <param name="request">The sale update request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale details</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSale([FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<UpdateSaleResponse>(response));
        }

        /// <summary>
        /// Cancel a sale
        /// </summary>
        /// <param name="id">The sale id to cancel</param>
        /// <param name="cancellationToken">Cancellation token</param>
        [HttpPatch("{id}/cancel")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelSale(Guid id, CancellationToken cancellationToken)
        {
            var request = new CancelSaleRequest { Id = id };
            var validator = new CancelSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CancelSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            if (!response.Success)
                return NotFound();

            return Ok(new ApiResponse { Success = true, Message = "Sale cancelled successfully." });
        }

        /// <summary>
        /// Cancel a sale
        /// </summary>
        /// <param name="id">The sale id to cancel</param>
        /// <param name="cancellationToken">Cancellation token</param>
        [HttpPatch("{id}/cancel/{itemId}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelSaleItem(Guid id, Guid itemId, CancellationToken cancellationToken)
        {
            var request = new CancelSaleItemRequest { SaleId = id, SaleItemId = itemId };
            var validator = new CancelSaleItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CancelSaleItemCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            if (!response.Success)
                return NotFound();

            return Ok(new ApiResponse { Success = true, Message = "Sale item cancelled successfully." });
        }
    }
}
