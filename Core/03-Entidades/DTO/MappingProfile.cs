using AutoMapper;
using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.models;

namespace TrabalhoFinal._03_Entidades.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Readcarrinho, Carrinho>().ReverseMap();
        }
    }
}
