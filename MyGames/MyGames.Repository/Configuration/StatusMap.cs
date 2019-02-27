using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGames.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Repository.Configuration
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.IdStatus);

            builder.Property(s => s.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
