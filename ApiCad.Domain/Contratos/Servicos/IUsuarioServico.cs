using ApiCad.Domain.Entidades;
using ApiCad.Domain.Modelos.Entradas;
using ApiCad.Domain.Modelos.Saidas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCad.Domain.Contratos.Servicos
{
    public interface IUsuarioServico
    {
        Task<Resposta> CadastrarUsuarioAsync(UsuarioCadastroModel model, CancellationToken cancellationToken = default);
    }
}
