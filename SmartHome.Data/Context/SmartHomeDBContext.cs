using Microsoft.Data.SqlClient;
using System.Data;

namespace SmartHome.Data.Context
{
    public class SmartHomeDBContext(SqlConnection connection)
    {
        private readonly SqlConnection _connection = connection;
        public async Task<int> ExecuteAsync(string query, params SqlParameter[] parameters)
        {
            await _connection.OpenAsync();
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters)
                    command.Parameters.AddWithValue(param.ParameterName, param.Value);
            }
            return await command.ExecuteNonQueryAsync();
        }
        public async Task<object?> ExecuteScalarAsync(string query, params SqlParameter[] parameters)
        {
            await _connection.OpenAsync();
            using SqlCommand command = new(query, connection);
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters)
                    command.Parameters.AddWithValue(param.ParameterName, param.Value);
            }
                
            return await command.ExecuteScalarAsync();
        }
        public async Task<DataTable> ExecuteReader(string query, params SqlParameter[] parameters)
        {
            await _connection.OpenAsync();
            using SqlDataAdapter adapter = new(query, connection);
            if (parameters.Length > 0)
            {
                foreach (SqlParameter param in parameters)
                    adapter.SelectCommand.Parameters.AddWithValue(param.ParameterName, param.Value);
            } 
                
            DataTable result = new();
            adapter.Fill(result);
            return result;
        }
    }
}
