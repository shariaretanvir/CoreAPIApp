using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.Classes
{
    public abstract class RepositoryBase
    {
        protected IDbTransaction Transaction { get; private set; }
        //protected IDbConnection Connection { get { return Transaction.Connection; } }
        protected IDbConnection Connection { get; private set; }
        public RepositoryBase(IDbConnection connection ,IDbTransaction dbTransaction)
        {
            this.Connection = connection;
            this.Transaction = dbTransaction;
        }
    }
}
