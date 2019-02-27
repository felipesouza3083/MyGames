using MyGames.Entities;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Persistence
{
    public class UsuarioRepository : BaseRepository<Usuario>,IUsuarioRepository
    {
        //atributo..
        private readonly DataContext context;

        public UsuarioRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }

        public Usuario Find(string login, string senha)
        {
            throw new NotImplementedException();
        }

        public bool HasLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
