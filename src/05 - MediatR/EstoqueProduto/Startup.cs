using System;
using System.Reflection;
using System.IO;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Services;
using EstoqueProduto.Infra.Data;
using EstoqueProduto.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using EstoqueProduto.Extensions;
using FluentValidation;
using MediatR;

namespace EstoqueProduto
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
            services.SwaggerConfigureServices();
            services.AutoMapperConfigureServices();
            services.DataBaseConfigureServices();
            services.IdentityUserConfigureServices(Configuration);
            services.DomainConfigureServices();      
            services.WebApiConfigureServices(Configuration);
            services.JwtConfigureServices(Configuration);
            services.AuthorizationConfigureServices();    
            services.AddMediatR(typeof(Startup));        
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            app.UseSwaggerConfigurationService();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

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
