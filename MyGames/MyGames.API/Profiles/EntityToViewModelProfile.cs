﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyGames.API.Models.Game;
using MyGames.API.Models.Perfil;
using MyGames.API.Models.Plataforma;
using MyGames.API.Models.Status;
using MyGames.API.Models.Usuario;
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

            CreateMap<Game, GameConsultaViewModel>()
                .AfterMap((src, dest) => dest.NomePlataforma = src.Plataforma.Nome)
                .AfterMap((src, dest) => dest.DescricaoStatus = src.Status.Descricao);

            CreateMap<Usuario, UsuarioAutenticadoViewModel>()
                .AfterMap((src, dest) => dest.NomePerfil = src.Perfil.Nome);
        }
    }
}
