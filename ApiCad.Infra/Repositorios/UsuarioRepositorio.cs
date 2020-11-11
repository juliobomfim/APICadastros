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
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SqliteDbContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Usuario>> RecuperarPorNomeAsync(string nome, CancellationToken cancellationToken = default) => _dataContext
            .Set<Usuario>()
            .Where(u => EF.Functions.Like(u.Nome, $"%{nome}%"))
            .ToListAsync(cancellationToken);

    }
}
