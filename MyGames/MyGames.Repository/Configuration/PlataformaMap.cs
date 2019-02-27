using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Configuration
{
    public class PlataformaMap : IEntityTypeConfiguration<Plataforma>
    {
        public void Configure(EntityTypeBuilder<Plataforma> builder)
        {
            builder.HasKey(p => p.IdPlataforma);

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
