using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Services;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Infrastructure.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioLocalizaBdd.CrossCuting
{
    public static class DependenciesResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IOperadorApplication, OperadorApplication>();
            services.AddScoped<ILoginApplication, LoginApplication>();
            services.AddSingleton<ITokenService, TokenService>();

            services.AddScoped<IVeiculoApplication, VeiculoApplication>();

            services.AddScoped<ILocacaoApplication, LocacaoApplication>();
            services.AddScoped<ICalculoService, CalculoService>();
            services.AddScoped<IDevolucaoApplication, DevolucaoApplication>();
            
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IOperadorRepositorio, OperadorRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
            services.AddScoped<IModeloRepositorio, ModeloRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();

            services.AddScoped<ILocacaoRepositorio, LocacaoRepositorio>();
        }
    }
}
