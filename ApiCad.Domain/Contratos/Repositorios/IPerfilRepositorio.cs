using ApiCad.Domain.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Domain.Contratos.Repositorios
{
    public interface IPerfilRepositorio : IRepositorio<Perfil>
    {
        Task<List<Perfil>> RecuperarPorNomeAsync(string nome, CancellationToken cancellationToken = default);
    }
}
