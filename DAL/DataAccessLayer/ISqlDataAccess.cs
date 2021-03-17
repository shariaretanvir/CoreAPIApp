using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessLayer
{
    public interface ISqlDataAccess
    {
        Task<int> Execute<T>(string sql, T data);
        Task<IEnumerable<T>> LoadData<T>(string sql, T data);
        T GetData<T>(string sql, T data);
        int ExecuteWithReturnValue(string sql, DynamicParameters parameters);
    }
}
