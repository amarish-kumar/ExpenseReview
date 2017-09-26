using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.Data.Contracts;

namespace ReimbursementApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ApproverListController :Controller
    {
        private IExpenseReviewUOW UOW;

        public ApproverListController(IExpenseReviewUOW uow)
        {
            UOW = uow;
        }

        [HttpGet("")]
        public IQueryable Get()
        {
            var model = UOW.ApproverLists.GetAll().OrderByDescending(emp => emp.Id);
            return model;
        }
    }
}
