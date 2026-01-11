using AjudAkiWeb.Models;
using AutoMapper;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class AssinaturaProfile : Profile
    {
        public AssinaturaProfile()
        {
            CreateMap<AssinaturaViewModel, Assinatura>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => (decimal)src.Valor))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ReverseMap()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => Enum.Parse<AssinaturaNomeEnum>(src.Nome)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<AssinaturaStatusEnum>(src.Status)))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor.HasValue ? (float)src.Valor.Value : 0f))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Descricao) ? src.Descricao : string.Empty))
                .ForMember(dest => dest.PlanoList, opt => opt.Ignore())
                .ForMember(dest => dest.StatusList, opt => opt.Ignore());
        }
    }
}
