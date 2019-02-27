using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Configuration
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.IdGame);

            builder.Property(g => g.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(g => g.IdStatus)
                .HasColumnName("IdStatus")
                .IsRequired();

            builder.Property(g => g.IdPlataforma)
                .HasColumnName("IdPlataforma")
                .IsRequired();

            builder.HasOne(g => g.Status)
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.IdStatus);

            builder.HasOne(g => g.Plataforma)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.IdPlataforma);
        }
    }
}
