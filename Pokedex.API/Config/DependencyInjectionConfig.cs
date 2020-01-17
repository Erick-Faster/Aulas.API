using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Pokedex.Api.Extensions;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Domain.Services;
using Pokedex.API.Extensions;
using Pokedex.API.Persistence.Repositories;
using Pokedex.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IHorarioService, HorarioService>();

            services.AddScoped<ILogAulaRepository, LogAulaRepository>();
            services.AddScoped<ILogAulaService, LogAulaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IHealthCheck, SqlServerHealthCheck>();

            return services;
        }
    }
}
