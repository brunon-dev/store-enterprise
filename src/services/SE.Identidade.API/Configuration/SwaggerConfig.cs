using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace SE.Identidade.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "Store Enterprise Identity API",
                    Description = "Esta API foi construída no projeto do curso ASP.NET Core Enterprise Application",
                    Contact = new OpenApiContact() { Name = "Bruno Nogueira", Url = new Uri(uriString: "https://brunon.com.br") },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri(uriString: "https://opensource.org/licenses/MIT") }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "v1");
            });

            return app;
        }
    }
}
