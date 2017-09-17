using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;

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
    }
}
