using AutoMapper;
using Domain.Commands.Requests;
using Domain.Models;

namespace Application.Configuration.Map
{
    public class ProductAutoMapping : Profile
    {
        public ProductAutoMapping()
        {
            CreateMap<ProductUpdateCommand, Product>();
        }
    }
}