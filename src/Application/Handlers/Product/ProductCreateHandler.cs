using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Notifications;
using MediatR;

namespace Application.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, DefaultResponse>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IRoomRepository _roomRepository;

        public ProductCreateHandler(IMediator mediator, IProductRepository productRepository, IBrandRepository brandRepository, IRoomRepository roomRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _roomRepository = roomRepository;
        }

        public async Task<DefaultResponse> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.RoomId);
            if (room == null)
                return await DefaultResponse.OK.AddValidationAsync("Room not found.");

            var brand = await _brandRepository.GetByIdAsync(request.BrandId);
            if (brand == null)
                return await DefaultResponse.OK.AddValidationAsync("Brand not found.");

            var product = new Product(
                Guid.NewGuid().ToString().ToUpper(),
                request.Description,
                room,
                brand,
                request.OriginalValue,
                request.SaleValue);

            await _productRepository.AddAsync(product);

            await _mediator.Publish(new ProductSuccessNotification($"Product was published successfully"), cancellationToken);

            return DefaultResponse.OK;
        }
    }
}