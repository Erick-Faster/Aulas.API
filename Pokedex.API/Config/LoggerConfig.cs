using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "6165e8859d7b47cd93ddc39db37e6862";
                o.LogId = new Guid("a23a4edf-6b5d-4b0c-9dc2-0b19daa86644");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "6165e8859d7b47cd93ddc39db37e6862";
                    o.LogId = new Guid("a23a4edf-6b5d-4b0c-9dc2-0b19daa86644");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            }
            );


            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
