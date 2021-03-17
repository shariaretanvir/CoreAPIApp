using CoreAPIApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeModel>
    {
    }
}
