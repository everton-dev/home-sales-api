using AutoMapper;
using Domain.Commands.Requests;
using Domain.Models;

namespace Application.Configuration.Map
{
    public class BrandAutoMapping : Profile
    {
        public BrandAutoMapping()
        {
            CreateMap<BrandUpdateCommand, Brand>();
        }
    }
}