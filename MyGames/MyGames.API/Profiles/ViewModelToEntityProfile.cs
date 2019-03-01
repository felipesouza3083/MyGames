using AutoMapper;
using MyGames.API.Models.Plataforma;
using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Profiles
{
    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<PlataformaCadastroViewModel, Plataforma>();
            CreateMap<PlataformaAtualizacaoViewModel, Plataforma>();
        }
    }
}
