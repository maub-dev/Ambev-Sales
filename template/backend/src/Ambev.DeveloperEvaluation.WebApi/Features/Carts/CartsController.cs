using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    /// <summary>
    /// Controller for managing carts operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Initializes a new instance of CartsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="configurationProvider">The AutoMapper configuration provider</param>
        public CartsController(IMediator mediator, IMapper mapper, AutoMapper.IConfigurationProvider configurationProvider)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
        }

        /// <summary>
        /// Gets the list of carts
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of carts</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<GetAllCartsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCartsRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetAllCartsRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetAllCartsCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = response.ProjectTo<GetAllCartsResponse>(_configurationProvider);

            return OkPaginated(await PaginatedList<GetAllCartsResponse>.CreateAsync(data, request.Page, request.Size));
        }

        /// <summary>
        /// Creates a new cart
        /// </summary>
        /// <param name="request">The cart creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
            {
                Success = true,
                Message = "Cart created successfully",
                Data = _mapper.Map<CreateCartResponse>(response)
            });
        }

        /// <summary>
        /// Deletes a cart
        /// </summary>
        /// <param name="id">The cart id to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCart(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteCartRequest { Id = id };
            var validator = new DeleteCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            if (!response.Success)
                return NotFound();

            return Ok(new ApiResponse { Success = true, Message = "Cart deleted successfully." });
        }
    }
}
