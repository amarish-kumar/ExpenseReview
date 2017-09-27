using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //TODO:- Search all is not working. Need to check
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
                        ExpenseDate = exp.ExpenseDate,
                        SubmitDate = exp.SubmitDate,
                        ApprovedDate = exp.Approvers.ApprovedDate,
                        Amount = exp.Amount,
                        TotalAmount = exp.TotalAmount,
                        ExpenseDetails = exp.ExpenseDetails,
                        ExpCategory = exp.ExpCategory,
                        TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                        ExpenseId = exp.Id,
                        reason = exp.Reason.Reasoning

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
                    ExpenseDate = exp.ExpenseDate,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id,
                    reason = exp.Reason.Reasoning

                });
            return model;

        }


        // GET api/expense/GetByName/saket
        [HttpGet("~/api/expense/GetByName/{EmployeeName}")]
        public IQueryable GetByName(string EmployeeName)
        {
           /* var model = UOW.Expenses.GetAll().Where(e => e.Employees.EmployeeName.StartsWith(EmployeeName));
            return model;*/
             var model = UOW.Expenses.GetAll().Where(e => e.Employees.EmployeeName.StartsWith(EmployeeName))
                 .Select(exp => new ExpenseViewModel
                 {
                     EmployeeId = exp.Employees.EmployeeId,
                     ApproverId = exp.Approvers.ApproverId,
                     ApprovedDate = exp.Approvers.ApprovedDate,
                     EmployeeName = exp.Employees.EmployeeName,
                     ApproverName = exp.Approvers.Name,
                     ExpenseDate = exp.ExpenseDate,
                     SubmitDate = exp.SubmitDate,
                     ExpCategory = exp.ExpCategory,
                     Amount = exp.Amount,
                     TotalAmount = exp.TotalAmount,
                     ExpenseDetails = exp.ExpenseDetails,
                     TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                     ExpenseId = exp.Id,
                     reason = exp.Reason.Reasoning
                     
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
                    ExpenseDate = exp.ExpenseDate,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id,
                    reason = exp.Reason.Reasoning

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
                    ExpenseDate = exp.ExpenseDate,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
                    ExpenseDetails = exp.ExpenseDetails,
                    ExpCategory = exp.ExpCategory,
                    TicketStatus = exp.Status.State.ToString().GetMyEnum().ToString(),
                    ExpenseId = exp.Id,
                    reason = exp.Reason.Reasoning
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
            var approverName = approver.FirstOrDefault().Name;
            var employee = UOW.Employees.GetAll().Where(emp => emp.UserName.Equals(User.Identity.Name));
            var emplName = employee.FirstOrDefault().EmployeeName;
            var empId = employee.FirstOrDefault().EmployeeId;
            var expCategory = UOW.ExpenseCategorySets.GetAll()
                .Where(exp => exp.CategoryId == expenseViewModel.ExpCategory.CategoryId);
            var catName = expCategory.FirstOrDefault().Category;
            var ExpenseObj = new Expense
            {
                Amount = expenseViewModel.Amount,
                TotalAmount = expenseViewModel.TotalAmount,
                ExpenseDate = expenseViewModel.ExpenseDate,
                SubmitDate = expenseViewModel.SubmitDate,
                Status = new TicketStatus {State = TicketState.Submitted, Reason = "Expense submitted by -" + emplName },
                Approvers = new Approver{ApproverId = expenseViewModel.ApproverId,Name = approverName},// approver.FirstOrDefault(),
                Employees = employee.FirstOrDefault(),
                ExpenseDetails = expenseViewModel.ExpenseDetails,
                ExpCategory = new ExpenseCategory { CategoryId = expenseViewModel.ExpCategory.CategoryId,Category = catName},
                Reason = new Reason { EmployeeId = empId,Reasoning = "Expense submitted by -"+emplName}
            };

            UOW.Expenses.Add(ExpenseObj);
            UOW.Commit();
            return Response.StatusCode = (int)HttpStatusCode.Created;
        }

       [HttpPut("")]
        public HttpResponseMessage Put([FromBody]ExpenseViewModel expense)
        {
            var expenseFetched = UOW.Expenses.GetAll().Where(exp => exp.Id == expense.ExpenseId)
                .Include(expense1 => expense1.Approvers)
                .Include(expense2 => expense2.Employees)
                .Include(expense3 => expense3.ExpCategory)
                .Include(expense4 => expense4.Reason)
                .Include(expense5 => expense5.Status);

           var expObj= expenseFetched.FirstOrDefault();
            expObj.Status.State = TicketState.ApprovedFromManager;
            //Check for current state.
            //some function, which will check current state and then it will set to next state.
            expObj.Approvers.ApprovedDate = expense.ApprovedDate;
            expObj.Approvers.Remarks = expense.reason;
           expObj.Reason = new Reason {EmployeeId = expense.EmployeeId, Reasoning = expense.reason};
            
       
             UOW.Expenses.Update(expObj);
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

