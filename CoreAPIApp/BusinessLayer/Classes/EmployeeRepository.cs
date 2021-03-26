using AutoMapper;
using CoreAPIApp.BusinessLayer.Interfaces;
using CoreAPIApp.Model;
using DAL.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.Classes
{
    public class EmployeeRepository : RepositoryBase,IEmployeeRepository
    {
        private readonly ISqlDataAccess sqlDataAccess;
        public EmployeeRepository(IDbConnection connection ,IDbTransaction transaction) : base(connection,transaction) //ISqlDataAccess sqlDataAccess, 
        {
            //this.sqlDataAccess = sqlDataAccess;
            this.sqlDataAccess = new SqlDataAccess(connection,transaction);
        }
        public Task<EmployeeModel> Delete(EmployeeModel model)
        {
            
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            //return await Connection.QueryAsync<EmployeeModel>("LstAllEmployee", new { }, Transaction);
            dynamic a = await sqlDataAccess.LoadData<object>("LstAllEmployee", new { });
            var config = new MapperConfiguration(cfg => { });
            var mapper = config.CreateMapper();

            IEnumerable<EmployeeModel> retUser = mapper.Map<IEnumerable<EmployeeModel>>(a);
            return retUser;
        }

        public async Task<int> Save(EmployeeModel model)
        {
            try {
                //return await Connection.ExecuteAsync("UpdEmployee @EmployeeId, @EmployeeName, @Salary, @Role", model,Transaction);
                return await sqlDataAccess.Execute("UpdEmployee @EmployeeId,@EmployeeName,@Salary,@Role", model);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            //return await sqlDataAccess.Execute("UpdEmployee @EmployeeId,@EmployeeName,@Salary,@Role", model);
        }

        public Task<EmployeeModel> Update(EmployeeModel model)
        {
            throw new NotImplementedException();
        }
    }
}
