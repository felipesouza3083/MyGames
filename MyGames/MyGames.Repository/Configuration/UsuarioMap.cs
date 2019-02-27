using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Configuration
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Login)
                .HasColumnName("Login")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(200)
                .IsRequired();


            builder.HasOne(u => u.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdPerfil);

        }
    }
}
