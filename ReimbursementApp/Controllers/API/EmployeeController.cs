using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;
using ReimbursementApp.Model;
using ReimbursementApp.ViewModels;

namespace ReimbursementApp.Controllers.API
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IExpenseReviewUOW UOW;

        public EmployeeController(IExpenseReviewUOW uow)
        {
            UOW = uow;
        }

        [HttpGet("")]
        public IQueryable Get()
        {
            var model = UOW.Employees.GetAll().OrderByDescending(emp => emp.Id);
            return model;
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var model = UOW.Employees.GetById(id);
            return model;
        }
        // Post a new Employee
        // POST /api/employee
        //TODO: Need to think on populating Employee and Approver Id
        [HttpPost("")]
        public int Post([FromBody]EmployeeViewModel employee)
        {

            var empObj = new Employee
            {
                EmployeeName = User.Identity.Name,
                Email=employee.Email,
                Mobile = employee.Mobile,
                AlternateNumber = employee.AlternateNumber,
                AddressLine1 = employee.AddressLine1,
                AddressLine2 = employee.AddressLine2,
                AddressLine3 = employee.AddressLine3,
                ZipCode = employee.ZipCode,
                Country = employee.Country,
                State = employee.State,
                //Need to check on below logic. May be this should be drop-down for 1st case
                //Below logic will change
                ReportingManager = employee.ReportingManager
            };

            UOW.Employees.Add(empObj);
            UOW.Commit();
            return Response.StatusCode = (int)HttpStatusCode.Created;
        }
    }
}
