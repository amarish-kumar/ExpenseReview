using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;
using ReimbursementApp.DbContext;
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

        // GET api/movies
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
                    ExpenseId = exp.Id
                    
                });
            return model;

        }
    }
}
