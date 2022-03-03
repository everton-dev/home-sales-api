using Application.Handlers;
using Application.Pipelines;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Notifications;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test
{
    public class ProductTest
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IBrandRepository> _brandRepository;
        private readonly Mock<IRoomRepository> _roomRepository;

        public ProductTest()
        {
            _mockMediator = new Mock<IMediator>();
            _productRepository = new Mock<IProductRepository>();
            _brandRepository = new Mock<IBrandRepository>();
            _roomRepository = new Mock<IRoomRepository>();

            _mockMediator.Setup(x => x.Publish(new ProductSuccessNotification(It.IsAny<string>()), It.IsAny<CancellationToken>()));
            _productRepository.Setup(x => x.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(DefaultResponse.OK));
            _brandRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new Brand(Guid.NewGuid().ToString(), "Brand Test")));
            _roomRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new Room(Guid.NewGuid().ToString(), "Room Test")));
        }

        [Fact]
        public async Task ValidateCreate_Must_Return_Room_Validate_Error()
        {

            var request = new ProductCreateCommand("test-product", "", Guid.NewGuid().ToString(), 123, 50);
            var handlerDelegate = new Mock<RequestHandlerDelegate<DefaultResponse>>();

            handlerDelegate.Setup(x => x.Invoke()).ReturnsAsync(new DefaultResponse());

            var handler = new ValidateCommandHandler<ProductCreateCommand, DefaultResponse>();
            var result = await handler.Handle(request, CancellationToken.None, handlerDelegate.Object);

            Assert.False(result.Success);
            Assert.NotEmpty(result.Erros);
        }

        [Fact]
        public async Task Product_Must_Return_Success()
        {
            var request = new ProductCreateCommand("test-product", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 123, 50);
            var handler = new ProductCreateHandler(_mockMediator.Object, _productRepository.Object, _brandRepository.Object, _roomRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result.Success);
        }
    }
}