using Microsoft.EntityFrameworkCore;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Repository.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        //atributo..
        private readonly DataContext context;

        //construtor com entrada de argumentos
        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual void Insert(T obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual List<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
