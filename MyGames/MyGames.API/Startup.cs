using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGames.API.Configuration;
using MyGames.API.Profiles;
using MyGames.Repository.Context;
using MyGames.Repository.Contracts;
using MyGames.Repository.Persistence;
using Swashbuckle.AspNetCore.Swagger;

namespace MyGames.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //mapear a injeção de dependencia..
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IPlataformaRepository, PlataformaRepository>();
            services.AddTransient<IGameRepository, GameRepository>();

            //registrando o AutoMapper..
            AutoMapperConfig.Register();

            services.AddMvc();

            services.AddDbContext<DataContext>(
                    options => options
                        .UseSqlServer(Configuration.GetConnectionString("Game"))
                );

            //configuração do swagger..
            services.AddSwaggerGen(
                    sw =>
                    {
                        sw.SwaggerDoc("v1", new Info
                        {
                            Title = "Controle de Games",
                            Description = "API para gerenciar os jogos.",
                            Version = "v1"
                        });
                    }
                );

            services.AddCors(
                    c => c.AddPolicy("DefaultPolicy",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        })
                );

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = "MyGamesAudience";
                paramsValidation.ValidIssuer = "MyGamesIssuer";

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json",
                                  "Projeto Asp.Net Core WebApi");
            });

            app.UseCors("DefaultPolicy");
        }
    }
}
