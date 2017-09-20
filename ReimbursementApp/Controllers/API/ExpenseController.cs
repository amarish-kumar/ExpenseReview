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
                        EmployeeName = exp.Employees.EmployeeName,
                        ApproverName = exp.Approvers.Name,
                        SubmitDate = exp.SubmitDate,
                        ApprovedDate = exp.Approvers.ApprovedDate,
                        Amount = exp.Amount,
                        TotalAmount = exp.TotalAmount,
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
                    EmployeeName = exp.Employees.EmployeeName,
                    ApproverName = exp.Approvers.Name,
                    SubmitDate = exp.SubmitDate,
                    ApprovedDate = exp.Approvers.ApprovedDate,
                    Amount = exp.Amount,
                    TotalAmount = exp.TotalAmount,
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
            var ExpenseObj = new Expense
            {
                Amount = expenseViewModel.TotalAmount,
                TotalAmount = expenseViewModel.TotalAmount,
                ExpenseDate = expenseViewModel.ExpenseDate,
                SubmitDate = expenseViewModel.SubmitDate,
                Status = new TicketStatus {State = TicketState.Submitted},
                Approvers = new Approver {Name = expenseViewModel.ApproverName},
                Employees = new Employee {EmployeeName = User.Identity.Name},
                ExpenseDetails = expenseViewModel.ExpenseDetails
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

