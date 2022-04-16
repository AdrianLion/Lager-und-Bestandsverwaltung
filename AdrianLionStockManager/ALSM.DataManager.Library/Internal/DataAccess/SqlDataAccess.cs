using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSM.DataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> Load<T, U>(string storedProcedure, U parameters, string connectionStringName = "ALSMData")
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);

            List<T> result = connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public void Save<T>(string storedProcedure, T parameters, string connectionStringName = "ALSMData")
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);

            connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
