using AutoMapper;
using Core;
using AjudAkiWeb.Models;
using System.Linq;

namespace AjudAkiWeb.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Servico, ServicoViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DataHoraSolicitacao, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTipoServico, opt => opt.MapFrom(src => src.IdTipoServico))
                .ForMember(dest => dest.IdAreaAtuacao, opt => opt.MapFrom(src => src.IdAreaAtuacao))
                .ForMember(dest => dest.IdProfissional, opt => opt.MapFrom(src => src.IdProfissional))

                .ForMember(dest => dest.TipoServicoNome, opt => opt.MapFrom(src => src.IdTipoServicoNavigation != null ? src.IdTipoServicoNavigation.Nome : null))
                .ForMember(dest => dest.AreaAtuacaoNome, opt => opt.MapFrom(src => src.IdAreaAtuacaoNavigation != null ? src.IdAreaAtuacaoNavigation.Nome : null))
                .ForMember(dest => dest.ProfissionalNome, opt => opt.MapFrom(src => src.IdProfissionalNavigation != null ? src.IdProfissionalNavigation.Nome : null))

                .ForMember(dest => dest.MediaAvaliacao, opt => opt.MapFrom(src =>
                    (src.Contratacaos != null && src.Contratacaos.SelectMany(c => c.Avaliacaos ?? new System.Collections.Generic.List<Avaliacao>()).Any())
                        ? src.Contratacaos.SelectMany(c => c.Avaliacaos ?? new System.Collections.Generic.List<Avaliacao>()).Average(a => (decimal)a.NotaProfissional)
                        : 0m
                ))

                .ForMember(dest => dest.FotoUrl, opt => opt.MapFrom(src => "/img/profile-placeholder.png"));

            // map back if needed
            CreateMap<ServicoViewModel, Servico>();
        }
    }
}
