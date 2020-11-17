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
    public class UsuarioController : ApiCadController
    {
        private readonly IUsuarioRepositorio _usuarioRep;
        private readonly IUsuarioServico _usuarioService;

        public UsuarioController(IServiceProvider serviceProvider, IUsuarioRepositorio usuarioRep, IUsuarioServico usuarioService) : base(serviceProvider)
        {
            _usuarioRep = usuarioRep;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string nome, CancellationToken cancellationToken) => Ok(await _usuarioRep.RecuperarPorNomeAsync(nome, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UsuarioCadastroModel model, CancellationToken cancellationToken) => await ExecutarAsync(_usuarioService.CadastrarUsuarioAsync(model, cancellationToken), cancellationToken);

    }
}
