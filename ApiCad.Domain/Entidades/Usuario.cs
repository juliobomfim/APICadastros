using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCad.Domain.Entidades
{
    public class Usuario:Entidade
    {
        protected Usuario() : base()
        {

        }

        public Usuario(string nome, string email, string senha, Perfil perfil):this()
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = perfil;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
