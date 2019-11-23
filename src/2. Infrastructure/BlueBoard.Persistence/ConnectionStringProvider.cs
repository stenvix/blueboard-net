using System.Runtime.CompilerServices;

using BlueBoard.Persistence.Abstractions;
using Dawn;
using Microsoft.Extensions.Configuration;

namespace BlueBoard.Persistence
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string connectionStringName;

        private readonly IConfiguration configuration;

        public ConnectionStringProvider(string connectionStringName, IConfiguration configuration)
        {
            Guard.Argument(connectionStringName).NotNull().NotEmpty();
            Guard.Argument(configuration).NotNull();

            this.connectionStringName = connectionStringName;
            this.configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connectionString = this.configuration.GetConnectionString(this.connectionStringName);
            return connectionString;
        }
    }
}
