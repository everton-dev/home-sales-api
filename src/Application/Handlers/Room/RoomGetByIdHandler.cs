using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class RoomGetByIdHandler : IRequestHandler<RoomGetByIdCommand, DefaultResponse<Room>>
    {
        private readonly IRoomRepository _RoomRepository;

        public RoomGetByIdHandler(IRoomRepository RoomRepository)
        {
            _RoomRepository = RoomRepository;
        }

        public async Task<DefaultResponse<Room>> Handle(RoomGetByIdCommand request, CancellationToken cancellationToken) =>
            new() { Data = await _RoomRepository.GetByIdAsync(request.Id) };
    }
}