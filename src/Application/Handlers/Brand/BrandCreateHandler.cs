using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class BrandCreateHandler : IRequestHandler<BrandCreateCommand, DefaultResponse>
    {
        private readonly IBrandRepository _BrandRepository;

        public BrandCreateHandler(IBrandRepository BrandRepository)
        {
            _BrandRepository = BrandRepository;
        }

        public async Task<DefaultResponse> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand(Guid.NewGuid().ToString(), request.Description ?? "");

            await _BrandRepository.AddAsync(brand);

            return DefaultResponse.OK;
        }
    }
}