using AjudAkiWeb.Models;
using AutoMapper;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class SolicitacaoServicoProfile : Profile
    {
        public SolicitacaoServicoProfile()
        {
            CreateMap<SolicitacaoServicoViewModel, Solicitacaoservico>().ReverseMap();
        }
    }
}
