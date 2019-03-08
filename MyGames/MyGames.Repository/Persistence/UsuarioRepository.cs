using Microsoft.EntityFrameworkCore;
using MyGames.Entities;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Repository.Persistence
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
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
            return context.Usuario
                          .Where(u => u.Login.Equals(login)
                                    && u.Senha.Equals(senha))
                          .Include(u=> u.Perfil)
                          .FirstOrDefault();
        }

        public bool HasLogin(string login)
        {
            return context.Usuario
                          .Count(u => u.Login.Equals(login)) > 0;
        }
    }
}
