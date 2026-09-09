using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DentalClinic_DataTier
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
            _connectionString =_connectionString.Insert(_connectionString.Length-1," ;Connect Timeout = 3");
            
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public bool TestConnection()
        {
            SqlConnection sqlConnection = CreateConnection();
            int test = sqlConnection.ConnectionTimeout;
          
            return true;
        }
    }
}
