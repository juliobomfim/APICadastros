using ApiCad.Domain.Entidades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Domain.Contratos.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        Task IncluirAsync(T entidade, CancellationToken cancellationToken = default);
        void ExcluirAsync(T entidade);
        Task<T> RecuperarAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
