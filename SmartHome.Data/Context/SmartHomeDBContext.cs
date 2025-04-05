using Microsoft.Data.SqlClient;
using System.Data;

namespace SmartHome.Data.Context
{
    public class SmartHomeDBContext(string connectionString)
    {
        private readonly string _connectionString = connectionString;
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<int> ExecuteAsync(string query, List<SqlParam> parameters = null)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                foreach (SqlParam param in parameters)
                    command.Parameters.AddWithValue(param.Name, param.Value);
            }
            return await command.ExecuteNonQueryAsync();
        }
        public async Task<object?> ExecuteScalarAsync(string query, List<SqlParam> parameters = null)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                foreach (SqlParam param in parameters)
                    command.Parameters.AddWithValue(param.Name, param.Value);
            }
                
            return await command.ExecuteScalarAsync();
        }
        public async Task<DataTable> ExecuteReader(string query, List<SqlParam> parameters = null)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            using SqlDataAdapter adapter = new(query, connection);
            if (parameters != null)
            {
                foreach (SqlParam param in parameters)
                    adapter.SelectCommand.Parameters.AddWithValue(param.Name, param.Value);
            } 
                
            DataTable result = new();
            adapter.Fill(result);
            return result;
        }
    }
}
