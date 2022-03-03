using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class RoomUpdateHandler : IRequestHandler<RoomUpdateCommand, DefaultResponse>
    {
        private IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public RoomUpdateHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<DefaultResponse> Handle(RoomUpdateCommand request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<RoomUpdateCommand, Room>(request);

            //Update Room in database
            await _roomRepository.UpdateAsync(room);

            //Return
            return DefaultResponse.OK;
        }
    }
}