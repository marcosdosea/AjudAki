using AutoMapper;
using AjudAkiWeb.Models;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class OfertarServicoProfile : Profile
    {
        public OfertarServicoProfile()
        {
            CreateMap<OfertarServicoViewModel, Servico>().ReverseMap();
        }
    }
}
