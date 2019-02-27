using MyGames.Entities;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
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
    }
}
