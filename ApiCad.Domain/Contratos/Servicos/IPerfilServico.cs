using ApiCad.Domain.Modelos.Entradas;
using ApiCad.Domain.Modelos.Saidas;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Domain.Contratos.Servicos
{
    public interface IPerfilServico
    {
        Task<Resposta> CadastrarPerfilAsync(PerfilCadastroModel model, CancellationToken cancellationToken = default);
    }
}
