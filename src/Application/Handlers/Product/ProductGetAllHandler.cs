using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class ProductGetAllHandler : IRequestHandler<ProductGetAllCommand, DefaultResponse<ICollection<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetAllHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DefaultResponse<ICollection<Product>>> Handle(ProductGetAllCommand request, CancellationToken cancellationToken) =>
            new() { Data = await _productRepository.GetAsync() };
    }
}