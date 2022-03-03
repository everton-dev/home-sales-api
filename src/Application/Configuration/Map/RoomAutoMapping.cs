using AutoMapper;
using Domain.Commands.Requests;
using Domain.Models;

namespace Application.Configuration.Map
{
    public  class RoomAutoMapping : Profile
    {
        public RoomAutoMapping()
        {
            CreateMap<RoomUpdateCommand, Room>();
        }
    }
}