using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCad.Domain.Entidades
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            var agora = DateTime.Now;
            Criacao = agora;
            Alteracao = agora;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime Alteracao { get; set; }
    }
}
