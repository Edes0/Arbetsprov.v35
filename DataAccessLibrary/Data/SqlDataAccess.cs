using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config) 
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string ConnectionString = _config.GetConnectionString(ConnectionStringName);

            using IDbConnection connection = new SqlConnection(ConnectionString);
            var data = await connection.QueryAsync<T>(sql, parameters);

            return data.ToList();
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string ConnectionString = _config.GetConnectionString(ConnectionStringName);

            using IDbConnection connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync(sql, parameters);
        }

        //public async Task SaveDataQuery(string sql)
        //{
        //    string ConnectionString = _config.GetConnectionString(ConnectionStringName);

        //    using IDbConnection connection = new SqlConnection(ConnectionString);
        //    await connection.ExecuteAsync(sql);
        //}
    }
}
