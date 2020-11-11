using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCad.Domain.Entidades
{
    public class Perfil : Entidade
    {

        public string Nome { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; }

        public Perfil(string nome) : this()
        {
            Nome = nome;
        }
        protected Perfil() : base()
        {
            Usuarios = new List<Usuario>();
        }
    }
}
