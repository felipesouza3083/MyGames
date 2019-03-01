using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyGames.API.Models.Perfil;
using MyGames.API.Models.Plataforma;
using MyGames.API.Models.Status;
using MyGames.Entities;

namespace MyGames.API.Profiles
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<Plataforma, PlataformaConsultaViewModel>();

            CreateMap<Status, StatusConsultaViewModel>();

            CreateMap<Perfil, PerfilConsultaViewModel>();
        }
    }
}
