using MyGames.Entities;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Persistence
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly DataContext context;

        public StatusRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
