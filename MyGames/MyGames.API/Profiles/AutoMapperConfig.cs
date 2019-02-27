using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Profiles
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToViewModelProfile>();
                cfg.AddProfile<ViewModelToEntityProfile>();
            });
        }
    }
}
