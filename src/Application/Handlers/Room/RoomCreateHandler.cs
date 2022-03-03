using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class RoomCreateHandler : IRequestHandler<RoomCreateCommand, DefaultResponse>
    {
        private readonly IRoomRepository _RoomRepository;

        public RoomCreateHandler(IRoomRepository RoomRepository)
        {
            _RoomRepository = RoomRepository;
        }

        public async Task<DefaultResponse> Handle(RoomCreateCommand request, CancellationToken cancellationToken)
        {
            var Room = new Room(Guid.NewGuid().ToString(), request.Description);

            await _RoomRepository.AddAsync(Room);

            return DefaultResponse.OK;
        }
    }
}