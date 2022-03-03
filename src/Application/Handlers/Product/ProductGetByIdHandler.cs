using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class ProductGetByIdHandler : IRequestHandler<ProductGetByIdCommand, DefaultResponse<Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DefaultResponse<Product>> Handle(ProductGetByIdCommand request, CancellationToken cancellationToken) =>
            new() { Data = await _productRepository.GetByIdAsync(request.Id) };
    }
}