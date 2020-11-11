using ApiCad.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCad.Infra.Mapeamentos
{
    public class UsuarioMap:EntidadeMap<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Senha).IsRequired();

            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.Usuarios);

            base.Configure(builder);
        }
    }
}
