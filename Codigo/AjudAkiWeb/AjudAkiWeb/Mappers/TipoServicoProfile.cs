using AutoMapper;
using AjudAkiWeb.Models;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class TipoServicoProfile : Profile
    {
        public TipoServicoProfile()
        {
            CreateMap<Tiposervico, TipoServicoViewModel>()
                .ForMember(dest => dest.NomeAreaAtuacao, opt => opt.MapFrom(src => src.IdAreaAtuacaoNavigation.Nome))
                .ForMember(dest => dest.DescricaoAgenda, opt => opt.MapFrom(src => $"{src.IdAgendaNavigation.Data:dd/MM/yyyy} - {src.IdAgendaNavigation.Turno}"));

            CreateMap<TipoServicoViewModel, Tiposervico>();
        }
    }
}
