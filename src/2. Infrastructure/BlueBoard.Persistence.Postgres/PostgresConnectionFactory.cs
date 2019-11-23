using System;
using System.Data;
using BlueBoard.Common;
using BlueBoard.Common.Exceptions;
using BlueBoard.Persistence.Abstractions;
using Dawn;
using Npgsql;

namespace BlueBoard.Persistence.Postgres
{
    public class PostgresConnectionFactory : IConnectionFactory
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public PostgresConnectionFactory(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection Create()
        {
            return this.CreateDbConnection(this.connectionStringProvider.GetConnectionString());
        }

        private IDbConnection CreateDbConnection(string connectionString)
        {
            Guard.Argument(connectionString).NotNull().NotEmpty();
            NpgsqlConnection connection = null;
            try
            {
                var fullConnectionString = this.GetConnectionString(connectionString);
                connection = new NpgsqlConnection(fullConnectionString);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                connection?.Close();
                Console.WriteLine(e);
                throw;
            }
        }

        private string GetConnectionString(string connectionString)
        {
            try
            {
                var builder = new NpgsqlConnectionStringBuilder(connectionString);

                return builder.ConnectionString;
            }
            catch (Exception e)
            {
                throw new BlueBoardException(ResponseCode.TechnicalError, e);
            }
        }
    }
}
