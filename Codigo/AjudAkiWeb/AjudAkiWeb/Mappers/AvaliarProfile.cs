using AjudAkiWeb.Models;
using AutoMapper;
using Core;
namespace AjudAkiWeb.Mappers
{
    public class AvaliarProfile : Profile
    {
        public AvaliarProfile()
        {
            CreateMap<AvaliarViewModel, Avaliacao>().ReverseMap();
        }
    }
}
