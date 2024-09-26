using AjudAkiWeb.Models;
using AutoMapper;
using Core;

namespace Mappers
{
    public class AssinaturaProfile : Profile
    {
        public AssinaturaProfile()
        {
            CreateMap<AssinaturaViewModel, Assinatura>().ReverseMap();
        }
    }
}
