using ApiCad.Abstrato;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiCad.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ApiCadController
    {
        public UsuarioController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
