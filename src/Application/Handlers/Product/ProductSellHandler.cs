using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Notifications;
using MediatR;

namespace Application.Handlers
{
    public class ProductSellHandler : IRequestHandler<ProductSellCommand, DefaultResponse<Domain.Models.Product>>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public ProductSellHandler(IMediator mediator, IProductRepository productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }

        public async Task<DefaultResponse<Domain.Models.Product>> Handle(ProductSellCommand request, CancellationToken cancellationToken)
        {
            //Get product from database
            var product = await _productRepository.GetByIdAsync(request.Id);

            await product.SellAsync(request.SoldBy);

            //Update product in database
            await _productRepository.UpdateAsync(product);

            await _mediator.Publish(new ProductSoldNotification($"Product was sold successfully"), cancellationToken);

            //Return
            return new()
            {
                Data = product
            };
        }
    }
}