using AjudAkiWeb.Models;
using AutoMapper;
using Core;


namespace AjudAkiWeb.Mappers
{
    public class AreaAtuacaoProfile : Profile
    {
        public AreaAtuacaoProfile()
        {
            CreateMap<Areaatuacao, AreaAtuacaoViewModel>()
                .ForMember(dest => dest.TiposServico, opt => opt.MapFrom(src => src.Tiposervicos))
                .ReverseMap();
        }
    }
}
