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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly DataContext context;

        public GameRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }

        public override List<Game> FindAll()
        {
            return context.Game
                          .Include(g => g.Plataforma)
                          .Include(g => g.Status)
                          .ToList();
        }

        public override Game FindById(int id)
        {
            return context.Game
                          .Include(g => g.Plataforma)
                          .Include(g => g.Status)
                          .FirstOrDefault();
        }
    }
}
