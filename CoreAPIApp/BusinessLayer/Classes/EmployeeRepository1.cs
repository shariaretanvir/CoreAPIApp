using CoreAPIApp.BusinessLayer.Interfaces;
using CoreAPIApp.Model;
using DAL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.Classes
{
    public class EmployeeRepository1 : RepositoryBase,IEmployeeRepository1
    {
        private readonly ISqlDataAccess sqlDataAccess;
        public EmployeeRepository1(IDbTransaction dbTransaction) : base(dbTransaction)
        {
            this.sqlDataAccess = new SqlDataAccess(Transaction);
        }

        public Task<EmployeeModel1> Delete(EmployeeModel1 model)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel1> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeModel1>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save(EmployeeModel1 model)
        {
            try
            {
                return await sqlDataAccess.Execute("UpdEmployee1 @EmployeeId,@EmployeeName,@Salary,@Role", model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<EmployeeModel1> Update(EmployeeModel1 model)
        {
            throw new NotImplementedException();
        }
    }
}
