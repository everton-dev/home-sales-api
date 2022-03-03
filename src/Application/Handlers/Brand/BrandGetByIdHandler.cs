using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class BrandGetByIdHandler : IRequestHandler<BrandGetByIdCommand, DefaultResponse<Brand>>
    {
        private readonly IBrandRepository _BrandRepository;

        public BrandGetByIdHandler(IBrandRepository BrandRepository)
        {
            _BrandRepository = BrandRepository;
        }

        public async Task<DefaultResponse<Brand>> Handle(BrandGetByIdCommand request, CancellationToken cancellationToken) =>
            new() { Data = await _BrandRepository.GetByIdAsync(request.Id) };
    }
}