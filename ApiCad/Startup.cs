
using CadastrarUsuario.Business.Servicos;
using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Contratos.Servicos;
using ApiCad.Domain.Contratos.Uow;
using ApiCad.Infra.Conexoes;
using ApiCad.Infra.Repositorios;
using ApiCad.Infra.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace CadastroUsuario
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqliteDbContext>(opts =>
                opts.UseSqlite("Data Source=ApiCad.db", sqlite => sqlite.MigrationsAssembly("ApiCad.Infra")));

            services.AddMvcCore((opts) =>
            {
                opts.EnableEndpointRouting = false;
            });

            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
            services.AddScoped<IPerfilServico, PerfilServico>();
            services.AddScoped<IUow, UnidadeDeTrabalho>();

            services.AddCors((e) =>
                e.AddPolicy("Dev", op => op
                .AllowAnyOrigin()
                .AllowAnyMethod()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Dev");
            }

            app.UseMvc();
        }
    }
}
