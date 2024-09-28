using AjudAkiWeb.Models;
using AutoMapper;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class ProfissionalProfile : Profile
    {
        public ProfissionalProfile()
        {
            CreateMap<ProfissionalViewModel, Pessoa>().ReverseMap();
            CreateMap<AssinaturaViewModel, Assinatura>().ReverseMap();
        }
    }
}
