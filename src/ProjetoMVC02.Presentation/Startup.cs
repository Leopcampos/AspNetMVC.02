using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoMVC02.Repository.Contracts;
using ProjetoMVC02.Repository.Repositories;

namespace ProjetoMVC02.Presentation
{
    public class Startup
    {
        //Propriedade para leitura do appsettings.json
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //habilitar o projeto para MVC..
            services.AddControllersWithViews();

            #region Configuração de injeção de dependência

            //lendo a connectionstringo do arquivo appsettings.json
            var connectionString = Configuration.GetConnectionString("ProjetoMVC02");

            //configurando a classe/interface UsuarioRepository
            services.AddTransient<IUsuarioRepository>(map => new UsuarioRepository(connectionString));

            //configurando a classe/interface PerfilRepository
            services.AddTransient<IPerfilRepository>(map => new PerfilRepository(connectionString));

            #endregion

            #region Configuração para autenticação

            //habilitando o uso de cookies no projeto
            services.Configure<CookiePolicyOptions>(op => { op.MinimumSameSitePolicy = SameSiteMode.None; });

            //definindo autenticação por meio de cookies (MVC)
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //habilitar a pasta /wwwroot
            app.UseStaticFiles();

            //habilitar autenticação
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //mapear a página inicial do projeto (default)
                endpoints.MapControllerRoute(
                    name: "default", //página padrão
                    pattern: "{controller=Account}/{action=Login}"
                );
            });
        }
    }
}