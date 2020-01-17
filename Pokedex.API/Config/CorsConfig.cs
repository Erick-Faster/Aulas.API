using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsConfiguration (this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //Aberto
                options.AddPolicy("Development",
                        builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());

                //Restritivo
                options.AddPolicy("Production",
                        builder => builder
                        .WithMethods("GET", "PUT")
                        .WithOrigins("http://desenvolvedor.io")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader());

            });

            return services;
        } 
    }
}
