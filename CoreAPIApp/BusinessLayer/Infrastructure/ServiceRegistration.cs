using CoreAPIApp.BusinessLayer.Classes;
using CoreAPIApp.BusinessLayer.Interfaces;
using CoreAPIApp.BusinessLayer.UnitOfWork;
using DAL.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIApp.BusinessLayer.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            //services.AddTransient<ISqlDataAccess, SqlDataAccess>();
        }
    }
}
