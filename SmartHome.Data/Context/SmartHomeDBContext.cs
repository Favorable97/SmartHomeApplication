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
        public async Task<int> ExecuteAsync(string query, SqlParameter[] parameters)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            using SqlCommand command = new(query, connection);
            if (parameters != null) 
                command.Parameters.AddRange(parameters);
            return await command.ExecuteNonQueryAsync();
        }
        public async Task<object?> ExecuteScalarAsync(string query, SqlParameter[] parameters)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            using SqlCommand command = new(query, connection);
            if (parameters != null) 
                command.Parameters.AddRange(parameters);
            return await command.ExecuteScalarAsync();
        }
        public async Task<DataTable> ExecuteReader(string query, SqlParameter[]? parameters = null)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            using SqlDataAdapter adapter = new(query, connection);
            if (parameters != null) 
                adapter.SelectCommand.Parameters.AddRange(parameters);
            DataTable result = new();
            adapter.Fill(result);
            return result;
        }
    }
}
