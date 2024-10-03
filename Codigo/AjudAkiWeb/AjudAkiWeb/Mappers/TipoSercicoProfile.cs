using AutoMapper;
using AjudAkiWeb.Models;
using Core;

namespace AjudAkiWeb.Mappers
{
    public class TipoSercicoProfile : Profile
    {
        public TipoSercicoProfile()
        {
            CreateMap<TipoServicoViewModel, Tiposervico>().ReverseMap();
        }
    }
}
