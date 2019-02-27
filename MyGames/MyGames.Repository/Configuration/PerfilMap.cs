using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Configuration
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(p => p.IdPerfil);

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
