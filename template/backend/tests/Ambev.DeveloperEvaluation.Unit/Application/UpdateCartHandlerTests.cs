using Ambev.DeveloperEvaluation.Application.Carts.Shared;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class UpdateCartHandlerTests
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly UpdateCartHandler _handler;

        public UpdateCartHandlerTests()
        {
            _cartRepository = Substitute.For<ICartRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateCartCommand, Cart>();
                cfg.CreateMap<Cart, UpdateCartResult>();
                cfg.CreateMap<CartItem, CartItemDto>().ReverseMap();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateCartHandler(_cartRepository, _mapper);
        }

        [Fact(DisplayName = "Handle should update cart successfully when command is valid and cart exists")]
        public async Task Handle_ShouldUpdateCart_WhenValid()
        {
            // Arrange
            var command = UpdateCardHandlerTestData.GenerateValidCommand();
            var mappedCart = _mapper.Map<Cart>(command);

            _cartRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult<Cart?>(mappedCart));

            _cartRepository.UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mappedCart));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(command.UserId);
            await _cartRepository.Received(1).UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Handle should throw ValidationException when command is invalid")]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new UpdateCartCommand
            {
                Id = Guid.Empty, // invalid
                Date = default, // invalid
                UserId = Guid.Empty, // invalid
                Products = [] // invalid
            };

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
            await _cartRepository.DidNotReceive().UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Handle should throw ValidationException when cart does not exist")]
        public async Task Handle_ShouldThrowValidationException_WhenCartNotFound()
        {
            // Arrange
            var command = UpdateCardHandlerTestData.GenerateValidCommand();

            _cartRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult<Cart?>(null));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>()
                .WithMessage($"*{command.Id} was not found*");
        }

        [Fact(DisplayName = "Handle should pass cancellation token to repository")]
        public async Task Handle_ShouldPassCancellationToken()
        {
            // Arrange
            var command = UpdateCardHandlerTestData.GenerateValidCommand();
            var mappedCart = _mapper.Map<Cart>(command);
            var cts = new CancellationTokenSource();

            _cartRepository.GetByIdAsync(command.Id, cts.Token)
                .Returns(Task.FromResult<Cart?>(mappedCart));

            _cartRepository.UpdateAsync(Arg.Any<Cart>(), cts.Token)
                .Returns(Task.FromResult(mappedCart));

            // Act
            var result = await _handler.Handle(command, cts.Token);

            // Assert
            result.Should().NotBeNull();
            await _cartRepository.Received(1).UpdateAsync(Arg.Any<Cart>(), cts.Token);
        }
    }
}
