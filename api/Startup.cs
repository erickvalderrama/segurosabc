using api.Clientes.Domain.Services;
using api.Clients.Infrastructure.Repository;
using api.Shared.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(Configuration);

            //context
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"))).AddTransient<AppDbContext>();

            //cors
            services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins,
                             builder => {
                                 builder.WithOrigins(Configuration["cors:url"]).AllowAnyHeader().AllowAnyMethod();
                             }));

            //swagger
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("0.1", new OpenApiInfo
                    {
                        Version = "0.1",
                        Title = "WS_Clients",
                        Description = "WS_Clients (ASP.NET Core 3.1)",
                        Contact = new OpenApiContact()
                        {
                            Name = "Erick Valderrama",
                            Url = new Uri("https://github.com/swagger-api/swagger-codegen"),
                            Email = "evalderramasanchez@gmail.com"
                        }
                    });
                });
            //logger
            services.AddMvc(option => option.EnableEndpointRouting = false);

            //Servicios
            services.AddTransient<ClientService, ClientServiceImpl>();

            //repositorios
            services.AddScoped<ClientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                    c.SwaggerEndpoint("/swagger/0.1/swagger.json", "API Clients");

                    //TODO: Or alternatively use the original Swagger contract that's included in the static files
                    // c.SwaggerEndpoint("/swagger-original.json", "API Gestión de Correo");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
