using ApiCad.Domain.Entidades;
using System;

namespace ApiCad.Domain.Modelos.Entradas
{
    public class UsuarioCadastroModel 
    { 
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid Perfil { get; set; }

        //[Required(ErrorMessage = "O Campo nome é obrigatório!"), StringLength(90, MinimumLength = 3, ErrorMessage = "O campo Nome não pode ter menos que 3 caracteres e mais que 90 caracteres")]
        //public string Nome { get; set; }

        //[Required(ErrorMessage = "O Campo E-mail é obrigatório!"), DataType(DataType.EmailAddress, ErrorMessage = "O E-mail não é válido!")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "O Campo senha é obrigatório!"), StringLength(3, MinimumLength = 20, ErrorMessage = "O campo Senha não pode ter menos que 3 caracteres e mais que 20 caracteres!")]
        //public string Senha { get; set; }

        //[Required(ErrorMessage = "O Perfil deve ser informado!")]
        //public Perfil Perfil { get; set; }
    }
}
