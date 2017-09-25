using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;

namespace ReimbursementApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ExpCategoryController : Controller
    {
        private IExpenseReviewUOW UOW;

        public ExpCategoryController(IExpenseReviewUOW uow)
        {
            UOW = uow;
        }

        [HttpGet("")]
        public IQueryable Get()
        {
            var model = UOW.ExpCategories.GetAll().OrderByDescending(exp=>exp.CategoryId);
            return model;
        }
    }
}
