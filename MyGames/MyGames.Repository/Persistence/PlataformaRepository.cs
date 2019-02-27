using MyGames.Entities;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Persistence
{
    public class PlataformaRepository:BaseRepository<Plataforma>, IPlataformaRepository
    {
        private readonly DataContext context;

        public PlataformaRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
