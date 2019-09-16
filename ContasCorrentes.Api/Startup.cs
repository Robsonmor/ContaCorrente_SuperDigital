using ContasCorrentes.Domain.Interfaces.Repositories;
using ContasCorrentes.Domain.Interfaces.Services;
using ContasCorrentes.Domain.Services;
using ContasCorrentes.Infrastructure.Data;
using ContasCorrentes.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace ContasCorrentes.Api
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
            var conexao = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFContext>(options => options.UseSqlServer(conexao));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Repositories
            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddTransient<ILancamentoRepository, LancamentoRepository>();

            //Services
            services.AddTransient<ILancamentoService, LancamentoService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Teste Conta Corrente", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Conta Corrente");
            });
        }
    }
}
