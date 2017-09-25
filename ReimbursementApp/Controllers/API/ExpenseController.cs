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
    public class ExpenseController : Controller
    {
        private IExpenseReviewUOW UOW;


        public ExpenseController(IExpenseReviewUOW uow)
        {
            UOW = uow;
        }

        // GET api/expense
        [HttpGet("")]
        public IQueryable Get()
        {
            var model = UOW.Expenses.GetAll().OrderByDescending(exp => exp.TotalAmount)
                    .Select(exp => new ExpenseViewModel
                    {
                        EmployeeId=exp.Employees.EmployeeId,
                        ApproverId = exp.Approvers.ApproverId,
                        EmployeeName = exp.Employees.EmployeeName,
                        ApproverName = exp.Approvers.Name,
                        SubmitDate = exp.SubmitDate,
                        ApprovedDate = exp.Approvers.ApprovedDate,
                        Amount = exp.Amount,
                        TotalAmount = exp.TotalAmount,
                        ExpenseDetails = exp.ExpenseDetails,
                        ExpCategory = exp.ExpCategory,
                        TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                        ExpenseId = exp.Id

                    });
            return model;

        }

        // GET api/expense/1
        [HttpGet("{id}")]
        public IQueryable Get(int id)
        {
            var model = UOW.Expenses.GetAll().Where(exp => exp.Id == id)
                .Select(exp => new ExpenseViewModel
                {
                    EmployeeId = exp.Employees.EmployeeId,
                    ApproverId = exp.Approvers.ApproverId,
                    EmployeeName = exp.Employees.EmployeeName,
                    ApproverName = exp.Approvers.Name,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id

                });
            return model;

        }


        // GET api/expense/GetByName/saket
        [HttpGet("~/api/expense/GetByName/{EmployeeName}")]
        public IQueryable GetByName(string EmployeeName)
        {
            var model = UOW.Expenses.GetAll().Where(e => e.Employees.EmployeeName.StartsWith(EmployeeName))
                .Select(exp => new ExpenseViewModel
                {
                    EmployeeId = exp.Employees.EmployeeId,
                    ApproverId = exp.Approvers.ApproverId,
                    EmployeeName = exp.Employees.EmployeeName,
                    ApproverName = exp.Approvers.Name,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id

                });
            return model;

        }

        // GET api/expense/GetByDesignation/SDE
        [HttpGet("~/api/expense/GetByDesignation/{Desig}")]
        public IQueryable GetByDesignation(string Desig)
        {
            var model = UOW.Expenses.GetAll().Where(e => e.Employees.Designation.StartsWith(Desig))
                .Select(exp => new ExpenseViewModel
                {
                    EmployeeId = exp.Employees.EmployeeId,
                    ApproverId = exp.Approvers.ApproverId,
                    EmployeeName = exp.Employees.EmployeeName,
                    ApproverName = exp.Approvers.Name,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id

                });
            return model;

        }

        // GET api/expense/GetByDesignation/SDE
        [HttpGet("~/api/expense/GetByManager/{Manager}")]
        public IQueryable GetByManager(string Manager)
        {
            var model = UOW.Expenses.GetAll().Where(e => e.Employees.ReportingManager.StartsWith(Manager))
                .Select(exp => new ExpenseViewModel
                {
                    EmployeeId = exp.Employees.EmployeeId,
                    ApproverId = exp.Approvers.ApproverId,
                    EmployeeName = exp.Employees.EmployeeName,
                    ApproverName = exp.Approvers.Name,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id

                });
            return model;

        }

        // Post a new Expense
        // POST /api/expense
        //TODO: Need to think on populating Employee and Approver Id
        [HttpPost("")]
        public int Post([FromBody]ExpenseViewModel expenseViewModel)
        {
           var approver= UOW.Approvers.GetAll().Where(app => app.ApproverId == expenseViewModel.ApproverId);
            string approverName = approver.FirstOrDefault().Name;
            //TODO: Fetch EmployeeID and name from employees via login name and then send down the line
            //var employee
            var ExpenseObj = new Expense
            {
                Amount = expenseViewModel.Amount,
                TotalAmount = expenseViewModel.TotalAmount,
                ExpenseDate = expenseViewModel.ExpenseDate,
                SubmitDate = expenseViewModel.SubmitDate,
                Status = new TicketStatus {State = TicketState.Submitted},
                Approvers = new Approver {ApproverId = expenseViewModel.ApproverId,Name = approverName},
                //Fetch employee id and name via service and then push the same here
                Employees = new Employee {EmployeeId = expenseViewModel.EmployeeId, EmployeeName = User.Identity.Name},
                ExpenseDetails = expenseViewModel.ExpenseDetails,
                ExpCategory = expenseViewModel.ExpCategory,
                Reason = new Reason { EmployeeId = expenseViewModel.EmployeeId,Reasoning = "Expense submitted by -"+expenseViewModel.EmployeeName}
            };

            UOW.Expenses.Add(ExpenseObj);
            UOW.Commit();
            return Response.StatusCode = (int)HttpStatusCode.Created;
        }

        // Update an existing expense
        // PUT /api/expense/
        //TODO:- Need to check if inifinite loop is happening,
        //Also, delete and update functionality will be available to admins
        [HttpPut("")]
        public HttpResponseMessage Put([FromBody]Expense expense)
        {
            UOW.Expenses.Update(expense);
            UOW.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/expense/5
        [HttpDelete("{Id}")]
        public HttpResponseMessage Delete(int Id)
        {
            UOW.Expenses.Delete(Id);
            UOW.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}

