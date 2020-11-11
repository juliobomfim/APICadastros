using ApiCad.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCad.Infra.Mapeamentos
{
    public class PerfilMap:EntidadeMap<Perfil>
    {
        public override void Configure(EntityTypeBuilder<Perfil> builder)
        {

            builder.ToTable("Perfil");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(x => x.Usuarios)
                .WithOne(x => x.Perfil);

            base.Configure(builder);
        }
    }
}
