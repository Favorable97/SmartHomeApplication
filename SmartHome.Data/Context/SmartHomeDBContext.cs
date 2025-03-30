using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SmartHome.Data.Context
{
    public class SmartHomeDBContext(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
