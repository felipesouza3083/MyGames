using AutoMapper;
using MyGames.API.Models.Game;
using MyGames.API.Models.Perfil;
using MyGames.API.Models.Plataforma;
using MyGames.API.Models.Status;
using MyGames.API.Models.Usuario;
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

            CreateMap<StatusCadastroViewModel, Status>();
            CreateMap<StatusAtualizacaoViewModel, Status>();

            CreateMap<PerfilCadastroViewModel, Perfil>();
            CreateMap<PerfilAtualizacaoViewModel, Perfil>();

            CreateMap<GameCadastroViewModel, Game>();
            CreateMap<GameAtualizacaoViewModel, Game>();

            CreateMap<UsuarioCadastroViewModel, Usuario>();
            CreateMap<UsuarioAutenticadoViewModel, Usuario>();
        }
    }
}
