using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class BrandUpdateHandler : IRequestHandler<BrandUpdateCommand, DefaultResponse>
    {
        private IMapper _mapper;
        private readonly IBrandRepository _BrandRepository;

        public BrandUpdateHandler(IMapper mapper, IBrandRepository BrandRepository)
        {
            _mapper = mapper;
            _BrandRepository = BrandRepository;
        }

        public async Task<DefaultResponse> Handle(BrandUpdateCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<BrandUpdateCommand, Brand>(request);

            //Update Brand in database
            await _BrandRepository.UpdateAsync(brand);

            //Return
            return DefaultResponse.OK;
        }
    }
}