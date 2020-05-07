using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EstoqueProduto.Extensions
{
    public static class SwaggerExtension
    {
        public static void SwaggerConfigureServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Estoque API",
                    Description = "Projeto WEB API para exercitar conceitos referente ao .net core",                    
                    Contact = new OpenApiContact
                    {
                        Name = "Junior Rocha",
                        Email = "juniorcesar.rocha@gmail.com",
                        Url = new Uri("https://github.com/juniorcesarrocha"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });
        }

        public static IApplicationBuilder UseSwaggerConfigurationService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estoque API V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}