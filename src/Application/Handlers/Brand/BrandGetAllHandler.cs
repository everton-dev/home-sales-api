using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class BrandGetAllHandler : IRequestHandler<BrandGetAllCommand, DefaultResponse<ICollection<Brand>>>
    {
        private readonly IBrandRepository _BrandRepository;

        public BrandGetAllHandler(IBrandRepository BrandRepository)
        {
            _BrandRepository = BrandRepository;
        }

        public async Task<DefaultResponse<ICollection<Brand>>> Handle(BrandGetAllCommand request, CancellationToken cancellationToken) =>
            new() { Data = await _BrandRepository.GetAsync() };
    }
}