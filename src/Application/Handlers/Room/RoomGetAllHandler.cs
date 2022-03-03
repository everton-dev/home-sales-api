using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class RoomGetAllHandler : IRequestHandler<RoomGetAllCommand, DefaultResponse<ICollection<Room>>>
    {
        private readonly IRoomRepository _RoomRepository;

        public RoomGetAllHandler(IRoomRepository RoomRepository)
        {
            _RoomRepository = RoomRepository;
        }

        public async Task<DefaultResponse<ICollection<Room>>> Handle(RoomGetAllCommand request, CancellationToken cancellationToken) =>
            new() { Data = await _RoomRepository.GetAsync() };
    }
}