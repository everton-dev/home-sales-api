using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class ProductUpdateHandler : IRequestHandler<ProductUpdateCommand, DefaultResponse>
    {
        private IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductUpdateHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<DefaultResponse> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductUpdateCommand, Product>(request);

            //Update product in database
            await _productRepository.UpdateAsync(product);

            //Return
            return DefaultResponse.OK;
        }
    }
}