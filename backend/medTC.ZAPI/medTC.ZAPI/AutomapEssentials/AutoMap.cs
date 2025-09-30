using AutoMapper;
using medTC.Domain.Models;
using medTC.Infrastructure.Repositorys.DTOS;

namespace medTC.ZAPI.AutomapEssentials
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
