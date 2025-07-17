using AjudAkiWeb.Models;
using AutoMapper;
using Core;


namespace AjudAkiWeb.Mappers
{
    public class AreaAtuacaoProfile : Profile
    {
        public AreaAtuacaoProfile()
        {
            CreateMap<AreaAtuacaoViewModel,Areaatuacao>().ReverseMap();
        }
    }
}
