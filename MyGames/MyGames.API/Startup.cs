using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGames.API.Profiles;
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
            //services.AddTransient<ISetorRepository, SetorRepository>();
            //services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

            //registrando o AutoMapper..
            AutoMapperConfig.Register();

            /*services.AddDbContext<DataContext>(
                    options => options
                        .UseSqlServer(Configuration.GetConnectionString("Aula"))
                );*/

            services.AddMvc();

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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
