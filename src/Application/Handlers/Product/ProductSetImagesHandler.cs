using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Cloud;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Cloud;
using MediatR;

namespace Application.Handlers
{
    public class ProductSetImagesHandler : IRequestHandler<ProductSetImagesCommand, DefaultResponse<Product>>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;
        private readonly IFileStorageCloud<FileStorageInput, FileStorageOutput> _fileStorageCloud;

        private const string BUCKET_FOLDER = "catalogo";

        public ProductSetImagesHandler(IMediator mediator, IProductRepository productRepository, IFileStorageCloud<FileStorageInput, FileStorageOutput> fileStorageCloud)
        {
            _mediator = mediator;
            _productRepository = productRepository;
            _fileStorageCloud = fileStorageCloud;
        }

        public async Task<DefaultResponse<Product>> Handle(ProductSetImagesCommand request, CancellationToken cancellationToken)
        {
            //Get product from database
            var product = await _productRepository.GetByIdAsync(request.Id);

            //AddImages in AWS S3
            foreach (var image in request.Images)
            {
                var output = await _fileStorageCloud.AddAsync(new(image.Name, BUCKET_FOLDER, image.Base64));
                await product.AddImageAsync(new(image.Name, image.Type, output.UrlFile));
            }

            //Update product in database
            await _productRepository.UpdateAsync(product);

            //Return
            return new()
            {
                Data = product
            };
        }
    }
}