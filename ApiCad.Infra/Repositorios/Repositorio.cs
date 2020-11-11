using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Entidades;
using ApiCad.Infra.Conexoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Infra.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        protected SqliteDbContext _dataContext;

        protected Repositorio(SqliteDbContext dataContext) => _dataContext = dataContext;
        public void ExcluirAsync(T entidade) => _dataContext.Set<T>().Remove(entidade);
        public async Task IncluirAsync(T entidade, CancellationToken cancellationToken = default) => await _dataContext.AddAsync(entidade, cancellationToken);
        public async Task<T> RecuperarAsync(Guid id, CancellationToken cancellationToken = default) => await _dataContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}
