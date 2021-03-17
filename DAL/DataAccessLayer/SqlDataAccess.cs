using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessLayer
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction transaction;
        public SqlDataAccess(IDbTransaction dbTransaction)
        {
            this.connection = dbTransaction.Connection;
            this.transaction = dbTransaction;
        }
        public async Task<int> Execute<T>(string sql, T data)
        {
            //return await connection.ExecuteAsync(sql, data,transaction);
            //using (IDbConnection con = new SqlConnection(DBConnection.GetDBConnection()))
            //{
                try
                {
                    return await transaction.Connection.ExecuteAsync(sql, data);
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            //}
        }

        public async Task<IEnumerable<T>> LoadData<T>(string sql, T data)
        {
            return await connection.QueryAsync<T>(sql, data, transaction);

            using (IDbConnection con = new SqlConnection(DBConnection.GetDBConnection()))
            {
                return await con.QueryAsync<T>(sql, data);
            }
        }

        public T GetData<T>(string sql, T data)
        {
            using (IDbConnection con = new SqlConnection(DBConnection.GetDBConnection()))
            {
                return con.Query<T>(sql, data).FirstOrDefault();
            }
        }

        public int ExecuteWithReturnValue(string sql, DynamicParameters parameters)
        {
            using (IDbConnection con = new SqlConnection(DBConnection.GetDBConnection()))
            {
                return con.Execute(sql,parameters);
            }
        }
    }
}
