using AutoMapper;
using Core;

namespace AjudAkiAPI.Mappers
{
    public class SolicitacaoServicoProfile : Profile
    {
        public SolicitacaoServicoProfile()
        {
            CreateMap<Models.SolicitacaoServicoViewModel, Solicitacaoservico>().ReverseMap();
        }
    }
}
