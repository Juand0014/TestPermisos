using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PermissionsTest API",
                    Contact = new OpenApiContact
                    {
                        Name = "Juan David Matos",
                        Email = "juand0014@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/juan-david-matos-553a73204/"),
                    }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseAppSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PermissionsTest API V1");
            });
            return app;
        }
    }
}
