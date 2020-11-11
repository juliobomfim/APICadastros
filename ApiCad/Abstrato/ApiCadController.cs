using ApiCad.Domain.Contratos.Uow;
using ApiCad.Domain.Modelos.Saidas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Abstrato
{
    public abstract class ApiCadController : Controller
    {
        private readonly IUow _uow;

        public ApiCadController(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUow>();
        }

        public async Task<IActionResult> ExecutarAsync<T>(Task<T> task, CancellationToken cancellationToken = default) where T : Resposta 
        {
            try
            {
                var resposta = await task;
                if (resposta.Tipo == RespostaTipo.Sucesso)
                    await _uow.CommitAsync(cancellationToken);

                return Ok(resposta);
            }catch(Exception ex)
            {
                return BadRequest(Resposta.Falha("Ocorreu um erro interno no servidor!", new
                {
                    ex.Message,
                    ex.StackTrace
                }));
            }
        }
    }
}
