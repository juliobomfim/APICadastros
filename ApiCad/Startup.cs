
using ApiCad.Business.Servicos;
using ApiCad.Domain.Contratos.Repositorios;
using ApiCad.Domain.Contratos.Servicos;
using ApiCad.Domain.Contratos.Uow;
using ApiCad.Infra.Conexoes;
using ApiCad.Infra.Repositorios;
using ApiCad.Infra.Uow;
using CadastrarUsuario.Business.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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
            })
            .AddNewtonsoftJson((opts) =>
            {
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();
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
