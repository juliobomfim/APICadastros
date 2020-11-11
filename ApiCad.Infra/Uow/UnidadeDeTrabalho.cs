using ApiCad.Domain.Contratos.Uow;
using ApiCad.Infra.Conexoes;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Infra.Uow
{
    public class UnidadeDeTrabalho : IUow
    {
        private readonly SqliteDbContext _dataContext;

        public UnidadeDeTrabalho(SqliteDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default) => await
            _dataContext.SaveChangesAsync(cancellationToken);
    }
}
