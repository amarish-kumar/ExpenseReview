using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IQueryable<Employee> Get(int id)
        {
            IQueryable<Employee> model = UOW.Employees.GetAll().Where(e => e.EmployeeId == id.ToString());
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
                EmployeeId = employee.EmployeeId,
                //Below practice is good for login/logout/admin access stuffs
                //EmployeeName = User.Identity.Name,
                EmployeeName = employee.EmployeeName,
                Gender = employee.Gender,
                Designation = employee.Designation,
                //Skillset will be comma-separated, so that later it can be listed as that.
                SkillSet = employee.SkillSet,
                Email=employee.Email,
                DOB = employee.DOB,
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
                ReportingManager = employee.ReportingManager,
                FatherName = employee.FatherName,
                MotherName = employee.MotherName,
                FatherDOB = employee.FatherDOB,
                MotherDOB = employee.MotherDOB,
                EmergencyContactName = employee.EmergencyContactName,
                EmergencyContactNumber = employee.EmergencyContactNumber,
                EmergencyContactRelation = employee.EmergencyContactRelation,
                EmergencyContactDOB = employee.EmergencyContactDOB,
                //Upon, sign up, this flag will automatically set to true.
                //Means, from next time user can't see this flow again
                SignedUp = true
            };

            UOW.Employees.Add(empObj);
            UOW.Commit();
            return Response.StatusCode = (int)HttpStatusCode.Created;
        }

        // Update an existing employee
        // PUT /api/employee/
        //TODO:- Need to check if inifinite loop is happening
        [HttpPut("")]
        public HttpResponseMessage Put([FromBody]Employee employeeViewModel)
        {
            UOW.Employees.Update(employeeViewModel);
            UOW.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/employee/5
        [HttpDelete("{EmployeeId}")]
        public HttpResponseMessage Delete(int EmployeeId)
        {
            UOW.Employees.Delete(EmployeeId);
            UOW.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


    }
}
