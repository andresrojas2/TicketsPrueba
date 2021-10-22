using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PruebasTicket.Logica.Repositorios;
using PruebasTicket.Logica.Contratos;
using PruebasTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebasTicket.Profiles;

namespace PruebasTicket
{
    public class Startup
    {
        readonly string MiCors = "MiCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebasTicket", Version = "v1" });
            });


            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                                  builder => {
                                      builder.WithHeaders("*"); //permite recibir cabeceras
                                      builder.WithOrigins("*"); //permite que los servicios sean llamado desde diferentes lugares (origen de datos)
                                      builder.WithMethods("*"); //permite metodo put y delete
                                  });


            });

            services.AddAutoMapper(typeof(PruebasTicketProfile));
            services.AddDbContext<PruebasTicketContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITicketRepositorio, RepositorioTicket>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebasTicket v1"));
            }

            app.UseCors(MiCors);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
