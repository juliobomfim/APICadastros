using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Contratos.Servicos;
using ApiCad.Domain.Entidades;
using ApiCad.Domain.Modelos.Entradas;
using ApiCad.Domain.Modelos.Saidas;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Business.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _rep;
        private readonly IPerfilRepositorio _perfilRep;

        public UsuarioServico(IUsuarioRepositorio rep, IPerfilRepositorio perfilRep)
        {
            _rep = rep;
            _perfilRep = perfilRep;
        }

        public async Task<Resposta> CadastrarUsuarioAsync(UsuarioCadastroModel model, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(model.Nome))
                return Resposta.Aviso("Nome do usuário não informado!");

            if (model.Nome.Length > 90)
                return Resposta.Aviso("Nome do perfil não pode conter mais que 90 carácteres!");

            var perfil = await _perfilRep.RecuperarAsync(model.Perfil);

            var usuario = new Usuario(model.Nome, model.Email, model.Senha, perfil);

            await _rep.IncluirAsync(usuario, cancellationToken);

            return Resposta.Sucesso($"Usuario {usuario.Nome} cadastrado com sucesso!", new { usuario.Id, usuario.Nome });
        }
    }
}
