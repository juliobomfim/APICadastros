using ApiCad.Abstrato;
using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Contratos.Servicos;
using ApiCad.Domain.Modelos.Entradas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PerfilController : CadastroUsuarioController
    {
        private readonly IPerfilRepositorio _perfilRepositorio;
        private readonly IPerfilServico _perfilServico;

        public PerfilController(IServiceProvider serviceProvider, IPerfilRepositorio perfilRepositorio, IPerfilServico perfilServico) : base(serviceProvider)
        {
            _perfilRepositorio = perfilRepositorio;
            _perfilServico = perfilServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string nome, CancellationToken cancellationToken) => Ok(await _perfilRepositorio.RecuperarPorNomeAsync(nome, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PerfilCadastroModel model, CancellationToken cancellationToken) => await ExecutarAsync(_perfilServico.CadastrarPerfilAsync(model, cancellationToken), cancellationToken);
    }
}
