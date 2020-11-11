using ApiCad.Domain.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Domain.Contratos.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<List<Usuario>> RecuperarPorNomeAsync(string nome, CancellationToken cancellationToken = default);
    }
}
