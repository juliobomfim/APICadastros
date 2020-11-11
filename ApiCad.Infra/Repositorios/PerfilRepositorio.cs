using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Entidades;
using ApiCad.Infra.Conexoes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Infra.Repositorios
{
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        public PerfilRepositorio(SqliteDbContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Perfil>> RecuperarPorNomeAsync(string nome, CancellationToken cancellationToken = default) => _dataContext.
            Set<Perfil>()
            .Where(p => EF.Functions.Like(p.Nome, $"%{nome}%"))
            .ToListAsync(cancellationToken);
    }
}
