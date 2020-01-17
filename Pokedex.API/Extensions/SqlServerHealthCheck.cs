using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pokedex.API.Extensions
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        readonly string _connection;
        readonly string _table;

        public SqlServerHealthCheck(string connection, string table)
        {
            _connection = connection;
            _table = table;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    await connection.OpenAsync(cancellationToken);

                    var command = connection.CreateCommand();
                    command.CommandText = "select count(id) from "+_table;

                    return Convert.ToInt32(await command.ExecuteScalarAsync(cancellationToken)) > 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy("Tabela " + _table + " possui menos que 3 registros");
                }
            }
            catch(Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }


}
