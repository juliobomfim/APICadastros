using ApiCad.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ApiCad.Infra.Mapeamentos
{
    public class EntidadeMap<T> : IEntityTypeConfiguration<T>where T:Entidade
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Criacao)
                .IsRequired();
            builder.Property(e => e.Alteracao)
                .IsRequired();

        }
    }
}
