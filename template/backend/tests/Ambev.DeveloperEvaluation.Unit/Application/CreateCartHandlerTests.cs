using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.Shared;
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
    public class CreateCartHandlerTests
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly CreateCartHandler _handler;

        public CreateCartHandlerTests()
        {
            _cartRepository = Substitute.For<ICartRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateCartCommand, Cart>();
                cfg.CreateMap<Cart, CreateCartResult>();
                cfg.CreateMap<CartItem, CartItemDto>().ReverseMap();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCartHandler(_cartRepository, _mapper);
        }

        [Fact(DisplayName = "Handle should create a cart successfully when command is valid")]
        public async Task Handle_ShouldCreateCart_WhenCommandIsValid()
        {
            // Arrange
            var command = CreateCartHandlerTestData.GenerateValidCommand();
            var mappedCart = _mapper.Map<Cart>(command);

            _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mappedCart));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(command.UserId);
            await _cartRepository.Received(1).CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Handle should throw ValidationException when command is invalid")]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new CreateCartCommand
            {
                Date = default, // invalid
                UserId = Guid.Empty, // invalid
                Products = [] // invalid
            };

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
            await _cartRepository.DidNotReceive().CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "Handle should map cart correctly to CreateCartResult")]
        public async Task Handle_ShouldMapCartCorrectly()
        {
            // Arrange
            var command = CreateCartHandlerTestData.GenerateValidCommand();
            var mappedCart = _mapper.Map<Cart>(command);

            _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mappedCart));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(command.UserId);
            result.Products.Should().HaveCount(command.Products.Count());
        }

        [Fact(DisplayName = "Handle should pass cancellation token to repository")]
        public async Task Handle_ShouldPassCancellationToken()
        {
            // Arrange
            var command = CreateCartHandlerTestData.GenerateValidCommand();
            var mappedCart = _mapper.Map<Cart>(command);
            var cts = new CancellationTokenSource();

            _cartRepository.CreateAsync(Arg.Any<Cart>(), cts.Token)
                .Returns(Task.FromResult(mappedCart));

            // Act
            var result = await _handler.Handle(command, cts.Token);

            // Assert
            result.Should().NotBeNull();
            await _cartRepository.Received(1).CreateAsync(Arg.Any<Cart>(), cts.Token);
        }
    }
}
