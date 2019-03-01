using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyGames.API.Models.Plataforma;
using MyGames.Entities;

namespace MyGames.API.Profiles
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<Plataforma, PlataformaConsultaViewModel>();
        }
    }
}
