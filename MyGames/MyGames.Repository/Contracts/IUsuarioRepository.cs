using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Find(string login, string senha);

        bool HasLogin(string login);
    }
}
