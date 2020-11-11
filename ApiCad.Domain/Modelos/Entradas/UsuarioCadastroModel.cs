using ApiCad.Domain.Entidades;

namespace ApiCad.Domain.Modelos.Entradas
{
    class UsuarioCadastroModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }
    }
}
