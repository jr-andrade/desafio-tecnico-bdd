using DesafioLocalizaBdd.Api.Logging;
using DesafioLocalizaBdd.CrossCuting;
using DesafioLocalizaBdd.Domain.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

namespace DesafioLocalizaBdd.Api
{
    /// <summary>
    /// Preparação do ambiente, configuração dos serviços e dependências
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuração
        /// </summary>

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configura os serviços
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSerilog();

            services.AddDependencyResolver();
            
            var chave = Encoding.ASCII.GetBytes(Constantes.CHAVE_TOKEN_AUTENTICACAO);
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DesafioLocalizaBdd",
                    Description = "API - DesafioLocalizaBdd",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "DesafioLocalizaBdd.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "DesafioLocalizaBdd.Application.xml");

                if (File.Exists(apiPath) && File.Exists(applicationPath))
                {
                    c.IncludeXmlComments(apiPath);
                    c.IncludeXmlComments(applicationPath);
                }
                
            });
        }

        /// <summary>
        /// Configura o ambiente
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/DesafioLocalizaBdd");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DesafioLocalizaBdd");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }              
    }
}
