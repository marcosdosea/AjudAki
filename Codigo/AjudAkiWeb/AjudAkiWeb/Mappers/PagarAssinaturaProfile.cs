using AjudAkiWeb.Models;
using AutoMapper;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class PagarAssinaturaProfile : Profile
    {
        public PagarAssinaturaProfile()
        {
            CreateMap<PagarAssinaturaViewModel, Pagamentoassinatura>().ReverseMap();
        }
    }
}
