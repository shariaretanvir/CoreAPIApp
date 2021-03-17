using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPIApp.BusinessLayer.UnitOfWork;
using CoreAPIApp.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreAPIApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IConfiguration configuration { get; set; }
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeController(IConfiguration con, IHostingEnvironment env,IUnitOfWork unitOfWork)
        {
            this.configuration = con;
            this.hostingEnvironment = env;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try {
                var task1 = await unitOfWork.EmployeeRepository.Save(new EmployeeModel
                {
                    EmployeeId = 0,
                    EmployeeName = "System1",
                    Role = "Auto",
                    Salary = "1"
                });
                var task2 = await unitOfWork.EmployeeRepository1.Save(new EmployeeModel1
                {
                    EmployeeId = 100,
                    EmployeeName = "System2",
                    Role = "Auto",
                    Salary = "1"
                });
                
                //await task1;
                //await task2;
                
                //await task1.ContinueWith((t)=> {
                //    throw new Exception(t.Exception.Message);
                //});
                //await task2.ContinueWith((t) => {
                //    throw new Exception(t.Exception.Message);
                //});
                //Task.Delay(2000).Wait();
                IEnumerable<EmployeeModel> employees = await unitOfWork.EmployeeRepository.GetAll();

                unitOfWork.Commit();
                return Ok("aaa");
            }
            catch (Exception e)
            {
                unitOfWork.Rollback();
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Route("SaveEmployee")]
        public IActionResult SaveEmployee(EmployeeModel employeeModel)
        {
            try
            {
                unitOfWork.EmployeeRepository.Save(employeeModel);
                return Ok("Saved");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
