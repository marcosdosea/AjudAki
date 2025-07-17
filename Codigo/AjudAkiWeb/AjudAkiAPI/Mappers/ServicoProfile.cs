using AutoMapper;
using AjudAkiWeb.Models;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<ServicoViewModel, Servico>().ReverseMap();
        }
    }
}
