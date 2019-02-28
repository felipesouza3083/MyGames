using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private static string _connectionString;

        public DataContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyGames;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(_connectionString);

            return new DataContext(optionsBuilder.Options);
        }

        private static void LoadConnectionString()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json", optional: false);

            IConfigurationRoot configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("Game");

            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("Not able to load connection string from appsettings.json");
        }
    }
}
