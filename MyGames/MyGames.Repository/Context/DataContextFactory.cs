using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"Data Source=SQL7002.site4now.net;Initial Catalog=DB_A40ECA_banco;User Id=DB_A40ECA_banco_admin;Password=admin123456;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
