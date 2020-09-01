using System;
using System.IO;
using System.Reflection;
using ContratosWebAPI.Aplicacao.Servico;
using ContratosWebAPI.Aplicacao.Servico.Interfaces;
using ContratosWebAPI.Dominio.Entidades.Interfaces;
using ContratosWebAPI.Dominio.Repositorio;
using ContratosWebAPI.Dominio.Servicos;
using ContratosWebAPI.Repositorio.Entidades;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;
using PrestacaosWebAPI.Dominio.Servicos;
using PrestacaosWebAPI.Repositorio.Entidades;

namespace ContratosWebAPI
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
            services.AddDbContext<Repositorio.ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ContratosWebAPI")));
                //options.UseInMemoryDatabase("ContratosWebAPI"));
            services.AddScoped<Repositorio.ApplicationDbContext, Repositorio.ApplicationDbContext>();

            services.AddMemoryCache();

            services.AddFeatureManagement();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Registra o gerador Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ContratosWebAPI",
                    Description = "API desenvolvida para o processo seletivo da IBM",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Zanelli",
                        Email = "zanelli@outlook.com",
                        Url = new Uri("https://www.linkedin.com/in/wzanelli/"),
                    }
                });

                // Caminho para o XML de configuração do Swagger JSON e da UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });


            // Serviço aplicação
            services.AddScoped<IServicoAplicacaoContrato, ServicoAplicacaoContrato>();
            //services.AddScoped<IServicoAplicacaoPrestacao, ServicoAplicacaoPrestacao>();

            // Domínio
            services.AddScoped<IServicoContrato, ServicoContrato>();
            services.AddScoped<IServicoPrestacao, ServicoPrestacao>();

            // Repositório
            services.AddScoped<IRepositorioContrato, RepositorioContrato>();
            services.AddScoped<IRepositorioPrestacao, RepositorioPrestacao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContratosWebAPI V1");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseResponseCaching(); //

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
