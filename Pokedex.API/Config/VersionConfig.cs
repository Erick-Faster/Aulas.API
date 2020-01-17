using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public static class VersionConfig
    {
        public static IServiceCollection AddVersionConfiguration (this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true; //assume um default qdo n ha v nenhum
                options.DefaultApiVersion = new ApiVersion(1, 0); //versao 1.0
                options.ReportApiVersions = true; //Diz que a API ta ok
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; //Nomenclatura
                options.SubstituteApiVersionInUrl = true; //Substitui na URL

            });

            return services;
        }
    }
}
