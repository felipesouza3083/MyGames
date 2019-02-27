using MyGames.Entities;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Persistence
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        //atributo..
        private readonly DataContext context;

        public PerfilRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
