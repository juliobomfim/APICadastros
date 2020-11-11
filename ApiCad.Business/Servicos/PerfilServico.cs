using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Contratos.Servicos;
using ApiCad.Domain.Entidades;
using ApiCad.Domain.Modelos.Entradas;
using ApiCad.Domain.Modelos.Saidas;
using System.Threading;
using System.Threading.Tasks;

namespace CadastrarUsuario.Business.Servicos
{
    public class PerfilServico : IPerfilServico
    {
        private readonly IPerfilRepositorio _repositorio;

        public PerfilServico(IPerfilRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Resposta> CadastrarPerfilAsync(PerfilCadastroModel model, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(model.Nome))
                return Resposta.Aviso("Nome do perfil não informado!");

            if (model.Nome.Length > 200)
                return Resposta.Aviso("Nome do perfil não pode conter mais que 200 carácteres!");

            var perfil = new Perfil(model.Nome);

            await _repositorio.IncluirAsync(perfil, cancellationToken);

            return Resposta.Sucesso($"Perfil {perfil.Nome} cadastrado com sucesso!", new { perfil.Id, perfil.Nome});
        }
    }
}
