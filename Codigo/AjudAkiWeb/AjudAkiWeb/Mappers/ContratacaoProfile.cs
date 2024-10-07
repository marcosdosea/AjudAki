using AjudAkiWeb.Models;
using AutoMapper;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class ContratacaoProfile : Profile
    {
        public ContratacaoProfile() {
            CreateMap<ContratacaoViewModel, Contratacao>().ReverseMap();
        }
    }
}
