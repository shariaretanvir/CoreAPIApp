using CoreAPIApp.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeRepository1 EmployeeRepository1 { get; }

        void Commit();
        void Rollback();
    }
}
