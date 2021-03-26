using CoreAPIApp.BusinessLayer.Classes;
using CoreAPIApp.BusinessLayer.Interfaces;
using DAL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ISqlDataAccess sqlDataAccess;
        private  IDbConnection _connection;
        private  IDbTransaction _transaction;
        private bool _disposed;

        private IEmployeeRepository employeeRepository;
        private IEmployeeRepository1 employeeRepository1;
        public UnitOfWork()
        {
            _connection = new SqlConnection("Server = DESKTOP-AKASH\\SQLEXPRESS; Database =TestDB;Trusted_Connection=True;");
            _connection.Open();
            //_transaction = _connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            //this.sqlDataAccess = sqlDataAccess;            
        }

        public IEmployeeRepository EmployeeRepository {
            get { return employeeRepository ?? (employeeRepository = new EmployeeRepository(_connection ,_transaction)); } 
        }

        public IEmployeeRepository1 EmployeeRepository1 {
            get { return employeeRepository1 ?? (employeeRepository1 = new EmployeeRepository1(_connection,_transaction)); }
        }

        public void Commit()
        {
            try {
                _transaction.Commit();
            }
            catch(Exception e) {
                _transaction.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        public void InitTransaction()
        {
            _transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }
        public void Rollback()
        {
            _transaction.Rollback();
            //throw new Exception(e.Message);
        }
        private void resetRepositories()
        {
            employeeRepository = null;           
        }


        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
