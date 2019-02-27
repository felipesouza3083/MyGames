using Microsoft.EntityFrameworkCore;
using MyGames.Entities;
using MyGames.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> builder)
            : base(builder)
        {

        }

        //método para definir as classes de mapeamento..
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new PlataformaMap());
            modelBuilder.ApplyConfiguration(new GameMap());
        }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario{ get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Plataforma> Plataforma { get; set; }
        public DbSet<Game> Game { get; set; }
    }
}
